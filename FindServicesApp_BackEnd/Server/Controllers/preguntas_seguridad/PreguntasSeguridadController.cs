using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Dto.preguntas_seguridadDto;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.Encriptador;
using FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindServicesApp_BackEnd.Server.Controllers.preguntas_seguridad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PreguntasSeguridadController : ControllerBase
    {

        private readonly AppDbContext context;

        public PreguntasSeguridadController(AppDbContext context)
        {
            this.context = context;

        }

        [HttpGet("tener/preguntas")]
        public async Task<ActionResult<List<Pregunta_Seguridad>>> Get()
        {
            var data = await context.Pregunta_Seguridad.OrderBy(x => x.Id).ToListAsync();

            return Ok(data);
        }

        [HttpPost("guardar/pregunta")]
         public async Task<ActionResult> GuardarPregunta(PreguntasSeguridadDto pregunta)
        {

            var data = await context.Pregunta_Contestadas.FirstOrDefaultAsync(x => x.RegistroUsuarioId == pregunta.idUsuario);

            if (data == null)
            {
                 
                var UserInfo = await context.Users.FirstOrDefaultAsync(x => x.Id == pregunta.idUsuario);

                if (UserInfo == null)
                {
                    //devuelve un 404
                    return NotFound();

                }

                Pregunta_Contestadas pregunta_Contestadas = new Pregunta_Contestadas();
                pregunta_Contestadas.respuesta = pregunta.respuesta;
                pregunta_Contestadas.PreguntaSeguridadId = int.Parse(pregunta.idPreguntaSeguridad);
                pregunta_Contestadas.RegistroUsuarioId = pregunta.idUsuario;

                context.Pregunta_Contestadas.Add(pregunta_Contestadas);
                await context.SaveChangesAsync();

                return Ok(new { res = "true" });

            }
            else
            {
                //el usuario no existe 
                return Ok(new { res = "false"  });
            }
 

        }

    }
}
