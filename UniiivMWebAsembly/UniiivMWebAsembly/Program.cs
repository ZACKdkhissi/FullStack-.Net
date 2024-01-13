using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using System.Net.Http.Headers;
using UniiivMWebAsembly;
using UniiivMWebAsembly.Services;
using Blazored.LocalStorage;
using System;
using System.Threading.Tasks;
using System.Threading;
using UniiivMWebAsembly.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

// Register your services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProfessorService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<TokenService>();

// Add HttpClient with DelegatingHandler
builder.Services.AddTransient<AuthTokenHandler>();
builder.Services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

await builder.Build().RunAsync();