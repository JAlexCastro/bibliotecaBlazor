using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorBiblioteca.Data;
using BlazorBiblioteca.Models;

namespace BlazorBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly LibroDBContext _context;

        // Inyeccion de dependencla del DbContext
        public LibroController(LibroDBContext context)
        {
            _context = context;
        }

        // =========================
        // GET: api/libro
        // =========================
        [HttpGet]
        public async Task<ActionResult<List<Libro>>> GetLibros()
        {
            var libros = await _context.Libros.ToListAsync();

            return Ok(libros);
        }

        // =========================
        // GET: api/libro/5
        // =========================
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
                return NotFound("Libro no encontrado");

            return Ok(libro);
        }

        // =========================
        // POST: api/libro
        // =========================
        [HttpPost]
        public async Task<ActionResult> CrearLibro([FromBody] Libro libro)
        {
            try
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();

                return Ok("Se ha ingresado un nuevo libro en la Biblioteca");
            }
            catch
            {
                return BadRequest("Error al ingresar nuevo Libro");
            }
        }

        // =========================
        // PUT: api/libro/5
        // =========================
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarLibro(int id, [FromBody] Libro libro)
        {
            // Verifica que el ID de la URL coincida con el ID del objeto enviado
            // Esto evita actualizar el libro incorrecto
            if (id != libro.Id)
                return BadRequest("ID no coincide");

            // Busca el libro en la base de datos por su ID
            var libroExistente = await _context.Libros.FindAsync(id);

            // Si no existe, devuelve error
            if (libroExistente == null)
                return NotFound($"Libro con ID {id} no existe");

            try
            {
                // Actualiza cada campo del libro existente con los nuevos datos
                libroExistente.NombreLibro = libro.NombreLibro;
                libroExistente.Autor = libro.Autor;
                libroExistente.NumPaginas = libro.NumPaginas;
                libroExistente.FechaPublicacion = libro.FechaPublicacion;

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Devuelve mensaje de éxito
                return Ok($"Se ha actualizado el libro {libro.NombreLibro}");
            }
            catch
            {
                // Si ocurre un error, devuelve mensaje de error
                return BadRequest($"Error al actualizar Libro {libro.NombreLibro}");
            }
        }

        // =========================
        // DELETE: api/libro/5
        // =========================
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
                return NotFound("Libro no encontrado");

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return Ok("Libro eliminado correctamente");
        }
    }
}