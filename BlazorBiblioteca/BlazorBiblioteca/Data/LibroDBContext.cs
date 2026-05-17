using BlazorBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorBiblioteca.Data
{
    public class LibroDBContext : DbContext
    {
        public LibroDBContext(DbContextOptions<LibroDBContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
    }
}