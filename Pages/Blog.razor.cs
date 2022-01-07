using HMZ4th.Services;
using HMZ4th.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HMZ4th.Pages
{
    public partial class Blog : ComponentBase
    {
        [Inject] HttpClient HttpClient { get; set; }

        string Content;
        async Task DoRandomRequest()
        {
            var res = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://reqres.in/api/users"));
            Content = await res.Content.ReadAsStringAsync();

            StateHasChanged();
        }
    }
}
