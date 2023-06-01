using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.Encriptador;
using FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad;
using FindServicesApp_BackEnd.Shared.Models.Profesiones;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindServicesApp_BackEnd.Server.Controllers.Profesiones
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProfesionesController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProfesionesController(AppDbContext context)
        {
            this.context = context;

        }

        [HttpGet("tener/profesiones")]
        public async Task<ActionResult<List<Profesion>>> Get()
        {
            var data = await context.Profesion.OrderBy(x => x.Id).ToListAsync();

            return Ok(data);
        }



        [HttpGet("idProfesional/{profesion}")]
        //con esta instruccion estamos diciendo que se ocupa el token
        public async Task<ActionResult> tenerIdProfesional(string profesion)
        {
            string pro = QuitarTildes(profesion.Replace(" ", "").ToLower());
            List<Profesion> profesions = await context.Profesion
                .ToListAsync();

            var data = profesions.FirstOrDefault(x => QuitarTildes(x.NombreProfesion.Replace(" ", "").ToLower()) == pro);


            //var cliente = context.Users.Include(c => c.DatosGenerales).FirstOrDefault(c => c.Id == 1);
            //return Ok(new { res = cliente });

            if (data == null)
            {
                
                return Ok(new {res="false",data= profesion.Replace(" ", "").ToLower() });
            }
            else
            {
                
 
                return Ok(new {res="true", modelo_pro = data });

            }

            /*
             coloco esta informacion aqui por si se desea hacer un filtrado
            usando lo quees DTO
            public class PersonaDTO
            {
                public int Id { get; set; }
                public string Nombre { get; set; }
                public int EstadoId { get; set; }
            }

             var personas = _context.Personas
            .Include(p => p.Estado)
            .Select(p => new PersonaViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                EstadoId = p.Estado.Id
            })
            .ToList();

            //otra forma
             
             var data = await context.Users
                 .Include(x => x.Roll)
                 .Include(x => x.DatosGenerales)
                 .Include(x => x.firma)
                  .Where(x => x.Id == id_convertido)
                 .Select(x => new
                 {
                     Rol = x.Roll.name,
                     Email = x.firma.Firma
                 })
                .FirstOrDefaultAsync( );
             
             */


        }



        public static string QuitarTildes(string texto)
        {
            var chars = new Dictionary<char, char>
        {
                {'á', 'a'},
                {'é', 'e'},
                {'í', 'i'},
                {'ó', 'o'},
                {'ú', 'u'},
                {'Á', 'A'},
                {'É', 'E'},
                {'Í', 'I'},
                {'Ó', 'O'},
                {'Ú', 'U'},
                {'ñ', 'n'},
                {'Ñ', 'N'}
            };

            var sb = new StringBuilder();

            foreach (char c in texto)
            {
                if (chars.TryGetValue(c, out char newChar))
                {
                    sb.Append(newChar);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

    }
}
