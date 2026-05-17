using BlazorBiblioteca.Client;
using BlazorBiblioteca.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);   


//  HttpClient hacia el backend (Server)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7298/")
});

//  Servicio
builder.Services.AddScoped<LibroService>();


await builder.Build().RunAsync();