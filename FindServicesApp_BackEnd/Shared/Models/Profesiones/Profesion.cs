using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.Profesiones
{
    public class Profesion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* Este Campo es Obligatorio.")]
        public string NombreProfesion { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
