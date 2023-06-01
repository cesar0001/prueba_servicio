using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Dto.planDto;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.plan_servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindServicesApp_BackEnd.Server.Controllers.plan_servicios
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PlanController : ControllerBase
    {

        private readonly AppDbContext context;

        public PlanController(AppDbContext context)
        {
            this.context = context;

        }


        [HttpGet("tipo/planes")]

        public async Task<ActionResult<List<Categoria_planes>>> tenerPlan()
        {
            

            var categoriasPlanes = await context.Categoria_Planes.Include(c => c.Planes).ToListAsync();


            return Ok(categoriasPlanes);
        }

        


    }
}
