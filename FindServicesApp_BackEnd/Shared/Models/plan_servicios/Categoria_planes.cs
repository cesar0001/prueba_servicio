using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.plan_servicios
{
    public class Categoria_planes
    {
        public int Id { get; set; }
        public string nombre_plan { get; set; }
        public int precio { get; set; }
        public List<Planes> Planes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
 
    }
}
