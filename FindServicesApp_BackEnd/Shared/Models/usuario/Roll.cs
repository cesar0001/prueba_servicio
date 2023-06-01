using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.usuario
{
    public class Roll
    {
        public int Id { get; set; }

        public string? name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }

    }
}
