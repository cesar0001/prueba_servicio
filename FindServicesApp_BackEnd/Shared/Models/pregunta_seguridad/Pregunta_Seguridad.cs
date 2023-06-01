using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad
{
    public class Pregunta_Seguridad
    {
        public int Id { get; set; }

        public string? descripcion { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
