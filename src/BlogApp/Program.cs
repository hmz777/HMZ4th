using BlogApp;
using BlogApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IStateContainer, AppStateContainer>();

builder.Services.AddSingleton<TransitionPageService>();
builder.Services.AddSingleton<NotificationService>();

builder.Services.AddScoped<HttpClientDelegator>();
builder.Services.AddHttpClient("Local", c => { c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); })
    .AddHttpMessageHandler<HttpClientDelegator>();
builder.Services.AddHttpClient("External").AddHttpMessageHandler<HttpClientDelegator>();

builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IBlogPostProcessorService, BlogPostProcessor>();

await builder.Build().RunAsync();