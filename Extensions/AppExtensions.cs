using HMZ4th.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddDelegatedHttpClient(this IServiceCollection services)
        {
            services.TryAddScoped<HttpClient>(provider =>
            {
                var delegator = provider.GetRequiredService<HttpClientDelegator>();
                return new HttpClient(delegator);
            });

            return services;
        }
    }
}
