using HMZ4th;
using HMZ4th.Extensions;
using HMZ4th.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<TransitionPageService>();
builder.Services.AddScoped<HttpClientDelegator>();
builder.Services.AddDelegatedHttpClient();

await builder.Build().RunAsync();