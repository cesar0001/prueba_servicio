using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Models.Encriptador;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindServicesApp_BackEnd.Server.Controllers.contrato
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ContratoController : ControllerBase
    {

        private readonly AppDbContext context;

        public ContratoController(AppDbContext context)
        {
            this.context = context;

        }


        [HttpGet("contratos")]
        public async Task<ActionResult> contratos()
        {
            var data = await context.Contratos
                .FirstOrDefaultAsync(x => x.status == "Activo");

            if(data == null)
            {
                return Ok(new {res="false"});
            }
            else
            {
                
                return Ok(new { res = "true", ids = data.Id.ToString(), contratos=data.contrato });
            }

             
        }

        [HttpGet("firmarContrato/{id}/{id_contrato}")]
        public async Task<ActionResult> FirmarContrato(string id, int id_contrato)
        {
            int id_convertido = int.Parse(Seguridad.DesEncriptar(id));
            var data = await context.Users
                .FirstOrDefaultAsync(x => x.Id == id_convertido);
 
            if (data == null)
            {
                 
                return Ok(new {res="false"});
            }
            else
            {
                data.UpdateAt = DateTime.Now;
                data.id_contrato = id_contrato;
                data.contrato_firmado = true;
                context.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(new { res = "true" });

            }

           
        }







    }
}
