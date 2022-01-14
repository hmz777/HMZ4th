using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Services
{
    public class HttpClientDelegator : DelegatingHandler
    {
        private readonly TransitionPageService transitionPageService;
        private readonly NotificationService notificationService;

        public HttpClientDelegator(TransitionPageService transitionPageService, NotificationService notificationService)
        {
            this.transitionPageService = transitionPageService;
            this.notificationService = notificationService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
                                       HttpRequestMessage request,
                                       CancellationToken cancellationToken = default)
        {

            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    //Cancel
                    transitionPageService.DoTransition(false);

                    notificationService.Show(new Models.NotificationMessageModel
                    {
                        NotificationMessage = "Operation canceled!",
                        NotificationType = Models.NotificationType.Warning
                    });

                    return default;
                }
                else
                    //Enable the loader component
                    transitionPageService.DoTransition(true);

                var ResponseMessage = await base.SendAsync(request, cancellationToken);

                //Disable the loader component
                transitionPageService.DoTransition(false);

                return ResponseMessage;
            }
            catch
            {
                notificationService.Show(new Models.NotificationMessageModel
                {
                    NotificationMessage = "Operation failed!",
                    NotificationType = Models.NotificationType.Error
                });

                return default;
            }
        }
    }
}
