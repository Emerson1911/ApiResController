using ENAE20230901ApiController.Models;
using Microsoft.AspNetCore.Mvc;

// Para obtener más información sobre cómo habilitar API Web para proyectos vacíos, visita https://go.microsoft.com/fwlink/?LinkID=397860

namespace ENAE20230901ApiController.Controllers
{
    // Define la ruta base para las solicitudes HTTP hacia este controlador como "api/[controller]".
    // [ApiController] indica que este controlador maneja solicitudes de API.
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        // Lista estática que actúa como una base de datos en memoria para almacenar objetos de tipo Alumnos.
        static List<Alumnos> alumnos = new List<Alumnos>();

        // GET: api/<AlumnoController>
        // Devuelve una lista de todos los alumnos.
        [HttpGet]
        public IEnumerable<Alumnos> Get()
        {
            return alumnos;
        }

        // GET api/<AlumnoController>/5
        // Devuelve un alumno específico basado en su ID.
        [HttpGet("{id}")]
        public Alumnos Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(c => c.id == id);
            return alumno;
        }

        // POST api/<AlumnoController>
        // Agrega un nuevo alumno a la lista.
        [HttpPost]
        public IActionResult Post([FromBody] Alumnos alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        // PUT api/<AlumnoController>/5
        // Actualiza la información de un alumno existente basado en su ID.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumnos alumno)
        {
            var existingAlumnos = alumnos.FirstOrDefault(c => c.id == id);
            if (existingAlumnos != null)
            {
                // Actualiza los campos del alumno existente con los valores del alumno recibido.
                existingAlumnos.name = alumno.name;
                existingAlumnos.lastname = alumno.lastname;
                existingAlumnos.email = alumno.email;
                existingAlumnos.phone = alumno.phone;
                existingAlumnos.city = alumno.city;
                return Ok();
            }
            else
            {
                // Retorna NotFound si el alumno no existe.
                return NotFound();
            }
        }

        // DELETE api/<AlumnoController>/5
        // Elimina un alumno basado en su ID.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumnos = alumnos.FirstOrDefault(c => c.id == id);
            if (existingAlumnos != null)
            {
                alumnos.Remove(existingAlumnos);
                return Ok();
            }
            else
            {
                // Retorna NotFound si el alumno no existe.
                return NotFound();
            }
        }
    }
}
