using System.Net.Http.Json;
using BlazorBiblioteca.Shared.Models;

namespace BlazorBiblioteca.Client.Services
{
    public class LibroService
    {
        private readonly HttpClient _http;

        public LibroService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Libro>> GetLibros()
        {
            return await _http.GetFromJsonAsync<List<Libro>>("api/libro") ?? new List<Libro>();
        }

        public async Task<string> CrearLibro(Libro libro)
        {
            var response = await _http.PostAsJsonAsync("api/libro", libro);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ActualizarLibro(Libro libro)
        {
            var response = await _http.PutAsJsonAsync($"api/libro/{libro.Id}", libro);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> EliminarLibro(int id)
        {
            var response = await _http.DeleteAsync($"api/libro/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}