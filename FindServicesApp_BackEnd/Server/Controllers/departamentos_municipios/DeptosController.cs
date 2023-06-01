using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindServicesApp_BackEnd.Server.Controllers.departamentos_municipios
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DeptosController : ControllerBase
    {

        private readonly AppDbContext context;
 

        public DeptosController(AppDbContext context )
        {
            this.context = context;
 
        }


        // GET: api/<DeptosController>
        [HttpGet("tener/deptos")]
        public async Task<ActionResult<List<Departamentos>>> Get()
        {
            return await context.departamentos.OrderBy(x => x.Nombre).ToListAsync();
        }

        // GET api/<DeptosController>/5
        [HttpGet("municipios/{DepartamentoId}")]
        public async Task<List<Municipio>> GetEstados(int DepartamentoId)
        {
            return await context.Municipios.Where(x => x.DepartamentoId == DepartamentoId)
                .OrderBy(x => x.Nombre).ToListAsync();
        }

    }
}
