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

        public HttpClientDelegator(TransitionPageService transitionPageService)
        {
            this.transitionPageService = transitionPageService;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
                                       HttpRequestMessage request,
                                       CancellationToken cancellationToken)
        {
            //Enable the loader component
            transitionPageService.DoTransition(true);

            var ResponseMessage = await base.SendAsync(request, cancellationToken);

            //Disable the loader component
            transitionPageService.DoTransition(false);

            return ResponseMessage;
        }
    }
}
