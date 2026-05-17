namespace BlazorBiblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string NombreLibro { get; set; }
        public string Autor { get; set; }
        public int NumPaginas { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}