using BlogApp.Models;
using BlogApp.Services;
using BlogApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogApp.Pages
{
    public partial class Contact : TransitionPageBase<Contact>
    {
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] NotificationService NotificationService { get; set; }
        [Inject] IConfiguration Configuration { get; set; }
        HttpClient HttpClient { get; set; }

        ContactModel ContactModel = new();
        EditContext? EditContext { get; set; }

        string SubmitButtonState;

        protected override void OnInitialized()
        {
            EditContext = new EditContext(ContactModel);
            HttpClient = HttpClientFactory.CreateClient("External");
        }

        async Task OnValidSubmit()
        {
            SubmitButtonState = "active";

            var captchaResponse = await PageModule.InvokeAsync<string>("GetRecaptchaResponse");

            if (string.IsNullOrWhiteSpace(captchaResponse))
            {
                var msg = new NotificationMessageModel
                {
                    NotificationMessage = $"ReCaptcha validation failed!",
                    NotificationType = NotificationType.Error
                };

                await InvokeAsync(() => { NotificationService.Show(msg); });
                SubmitButtonState = "";
                return;
            }

            ContactModel.RecpatchaResponse = captchaResponse;

            var message = new HttpRequestMessage(HttpMethod.Post, "https://formcarry.com/s/OuVfZ9lLxyz");
            message.Headers.Clear();
            message.SetBrowserRequestMode(BrowserRequestMode.Cors);
            message.Headers.Add("Accept", "application/json");
            message.Content = new StringContent(JsonSerializer.Serialize(EditContext.Model), Encoding.UTF8, "application/json");
            var res = await HttpClient.SendAsync(message, HttpCompletionOption.ResponseContentRead);

            if (res.IsSuccessStatusCode == false)
            {
                NotificationMessageModel msg = null;

                msg = (int)res.StatusCode switch
                {
                    406 => new NotificationMessageModel
                    {
                        NotificationMessage = $"Message not sent!<br />" +
                                              "Possible Cause: Request missing some parameters<br />" +
                                              $"Status code: {(int)res.StatusCode}",
                        NotificationType = NotificationType.Error
                    },
                    403 => new NotificationMessageModel
                    {
                        NotificationMessage = $"Message not sent!<br />" +
                          "Possible Cause: ReCaptcha not checked<br />" +
                          $"Status code: {(int)res.StatusCode}",
                        NotificationType = NotificationType.Error
                    },
                    _ => new NotificationMessageModel
                    {
                        NotificationMessage = $"Message not sent!<br />" +
                        $"Status code: {(int)res.StatusCode}",
                        NotificationType = NotificationType.Error
                    },
                };

                await InvokeAsync(() => { NotificationService.Show(msg); });
            }
            else
            {
                ContactModel = new ContactModel();
                EditContext = new EditContext(ContactModel);

                var notifMessage = new NotificationMessageModel
                {
                    NotificationMessage = "Message sent successfully!",
                    NotificationType = NotificationType.Success
                };

                await InvokeAsync(() => { NotificationService.Show(notifMessage); });
            }

            SubmitButtonState = "";
        }

        async Task OnInValidSubmit()
        {
            var notifMessage = new NotificationMessageModel
            {
                NotificationMessage = "Invalid message!",
                NotificationType = NotificationType.Error
            };

            await InvokeAsync(() => { NotificationService.Show(notifMessage); });
        }
    }
}
