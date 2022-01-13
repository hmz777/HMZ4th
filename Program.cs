using HMZ4th;
using HMZ4th.Extensions;
using HMZ4th.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<TransitionPageService>();
builder.Services.AddSingleton<NotificationService>();

builder.Services.AddScoped<HttpClientDelegator>();
builder.Services.AddHttpClient("Local", c => { c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); })
    .AddHttpMessageHandler<HttpClientDelegator>();
builder.Services.AddHttpClient("External").AddHttpMessageHandler<HttpClientDelegator>();
//implement In-memory state container service
await builder.Build().RunAsync();