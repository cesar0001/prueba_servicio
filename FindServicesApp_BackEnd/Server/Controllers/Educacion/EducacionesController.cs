using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Models.eduacion;
using FindServicesApp_BackEnd.Shared.Models.experiencia_laboral;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindServicesApp_BackEnd.Server.Controllers.Educacion
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class EducacionesController : ControllerBase
    {
        private readonly AppDbContext context;

        public EducacionesController(AppDbContext context)
        {
            this.context = context;

        }

        [HttpPost("guardar/educacion")]
        public async Task<ActionResult> GuardarEducaicon(FindServicesApp_BackEnd.Shared.Models.eduacion.Educacion educa)
        {
 
            var data = await context.Educacion.FirstOrDefaultAsync(x => x.Id == educa.Id);

            if (data == null)
            {

                context.Educacion.Add(educa);
                await context.SaveChangesAsync();

                return Ok(new { res = "true" });

            }
            else
            {
 
 
                data.UpdateAt = DateTime.Now;
    
                data.Titulo = educa.Titulo;
                data.Centro_Estudio = educa.Centro_Estudio;
                data.Modalidad_Estudio = educa.Modalidad_Estudio;
                data.Nivel_Estudio = educa.Nivel_Estudio;
                data.MunicipioId = educa.MunicipioId;
                data.DepartamentoId = educa.DepartamentoId;
                data.Desde = educa.Desde;
                data.Hasta = educa.Hasta;
                context.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();
                //el usuario no existe 
                return Ok(new { res = "true" });
            }


        }


        [HttpGet("tener/educacion/{id_usuario}")]
 
        public async Task<List<FindServicesApp_BackEnd.Shared.Models.eduacion.Educacion>> tenerListadoExperiencia(int id_usuario)
        {
            var data = await context.Educacion
                .Include(x => x.Estado)
                .Include(x => x.Departamento)
                .Where(x => x.RegistroUsuarioId == id_usuario)
                .OrderBy(x => x.Id).ToListAsync();

            //data = await context.Municipios.Where(x => x.DepartamentoId == data)
            //    .OrderBy(x => x.Nombre).ToListAsync();

            return data;
        }


        [HttpPost("eliminar/educacion")]
        public async Task<ActionResult> EliminarExperienciaLab(FindServicesApp_BackEnd.Shared.Models.eduacion.Educacion educacion)
        {


            var data = await context.Educacion.FirstOrDefaultAsync(x => x.Id == educacion.Id);

            if (data == null)
            {

                //el usuario no existe 
                return Ok(new { res = "false" });
            }
            else
            {
                context.Educacion.Remove(data);
                await context.SaveChangesAsync();

                return Ok(new { res = "true" });

            }


        }

        [HttpGet("tener/educacion/individual/{id_educacion}")]
        public async Task<ActionResult> tenerExperiencia(int id_educacion)
        {

            var data = await context.Educacion.FirstOrDefaultAsync(x => x.Id == id_educacion);
            return Ok(new { modelo_educacion = data });

        }
    }
}
