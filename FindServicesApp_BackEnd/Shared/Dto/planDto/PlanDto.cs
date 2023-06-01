using FindServicesApp_BackEnd.Shared.Models.plan_servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.planDto
{
    public class PlanDto
    {
        public int Id_general { get; set; }
        public string nombre_categoria { get; set; }
        public string descripcion_categoria { get; set; }
 
    }
}
