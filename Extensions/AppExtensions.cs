using HMZ4th.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddDelegatedHttpClient(this IServiceCollection services, string BaseAddress)
        {
            services.TryAddScoped<HttpClient>(provider =>
            {
                var delegator = provider.GetRequiredService<HttpClientDelegator>();
                return new HttpClient(delegator) { BaseAddress = new Uri(BaseAddress) };
            });

            return services;
        }

        public static async Task<T> GetFromJsonAsync<T>(this HttpClient httpClient, string requestUri,
            TransitionPageService transitionPageService,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(transitionPageService);

            if (cancellationToken != default && cancellationToken.IsCancellationRequested)
            {
                //Cancel
                transitionPageService.DoTransition(false);
                return default;
            }
            else
                //Enable the loader component
                transitionPageService.DoTransition(true);

            var res = await httpClient.GetFromJsonAsync<T>(requestUri, cancellationToken);

            //Disable the loader component
            transitionPageService.DoTransition(false);

            return res;
        }
    }
}
