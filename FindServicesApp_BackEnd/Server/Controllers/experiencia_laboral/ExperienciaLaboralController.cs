using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Dto.preguntas_seguridadDto;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.experiencia_laboral;
using FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindServicesApp_BackEnd.Server.Controllers.experiencia_laboral
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ExperienciaLaboralController : ControllerBase
    {
        private readonly AppDbContext context;

        public ExperienciaLaboralController(AppDbContext context)
        {
            this.context = context;

        }

        [HttpPost("guardar/experiencia")]
        public async Task<ActionResult> GuardarExperienciaLab(Experiencia_Laboral experiencia)
        {

            //context.Experiencia_Laboral.Add(experiencia);
            //await context.SaveChangesAsync();

            //return Ok(new { res = "true", experiencia_lab = experiencia});
            var data = await context.Experiencia_Laboral.FirstOrDefaultAsync(x => x.Id == experiencia.Id);

            if (data == null)
            {

                context.Experiencia_Laboral.Add(experiencia);
                await context.SaveChangesAsync();

                return Ok(new { res = "true", experiencia_lab = experiencia });

            }
            else
            {

                data.UpdateAt = DateTime.Now;
                data.Posicion_Laboral = experiencia.Posicion_Laboral;
                data.Compañia = experiencia.Compañia;
                data.Salario = experiencia.Salario;
                data.MunicipioId = experiencia.MunicipioId;
                data.DepartamentoId = experiencia.DepartamentoId;
                data.Descripcion = experiencia.Descripcion;
                data.Desde = experiencia.Desde;
                data.Hasta = experiencia.Hasta;
                context.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();
                //el usuario no existe 
                return Ok(new { res = "true" });
            }


        }

        [HttpGet("tener/experiencia/{id_usuario}")]
        public async Task<List<Experiencia_Laboral>> tenerListadoExperiencia(int id_usuario)
        {
            var data = await context.Experiencia_Laboral
                .Include(x => x.Estado)
                .Include(x => x.Departamento)
                .Where(x => x.RegistroUsuarioId == id_usuario)
                .OrderBy(x => x.Id).ToListAsync();

            //data = await context.Municipios.Where(x => x.DepartamentoId == data)
            //    .OrderBy(x => x.Nombre).ToListAsync();

            return data;
        }


        [HttpPost("eliminar/experiencia")]
        public async Task<ActionResult> EliminarExperienciaLab(Experiencia_Laboral experiencia)
        {


            var data = await context.Experiencia_Laboral.FirstOrDefaultAsync(x => x.Id == experiencia.Id);

            if (data == null)
            {

                 //el usuario no existe 
                return Ok(new { res = "false" });
            }
            else
            {
                context.Experiencia_Laboral.Remove(data);
                await context.SaveChangesAsync();

                return Ok(new { res = "true"  });

            }


        }

        [HttpGet("tener/experiencia/individual/{id_experiencia}")]
        public async Task<ActionResult> tenerExperiencia(int id_experiencia)
        {
        
            var data = await context.Experiencia_Laboral.FirstOrDefaultAsync(x => x.Id == id_experiencia);
            return Ok(new { experiencia_lab = data });
           
        }



    }
}
