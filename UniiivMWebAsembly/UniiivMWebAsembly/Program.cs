using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UniiivMWebAsembly;
using UniiivMWebAsembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProfessorService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<StudentService>();






await builder.Build().RunAsync();
