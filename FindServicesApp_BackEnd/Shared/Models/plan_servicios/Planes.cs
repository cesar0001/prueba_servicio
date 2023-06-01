using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.plan_servicios
{
    public class Planes
    {
        public int Id { get; set; }
        public string descripcion { get; set; }

        public int id_categoria { get; set; }
        public Categoria_planes? Categoria_Planes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
