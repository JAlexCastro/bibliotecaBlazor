using System.ComponentModel.DataAnnotations;

namespace BlazorBiblioteca.Shared.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del libro es obligatorio")]
        public string NombreLibro { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; }

        [Range(1, 10000, ErrorMessage = "Número de páginas inválido")]
        public int NumPaginas { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime FechaPublicacion { get; set; }
    }
}