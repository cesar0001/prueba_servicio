using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.usuario
{
    public class FirmaContrato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El Campo Firma es Obligatorio.")]
        public string Firma { get; set; }

        public int RegistroUsuarioId { get; set; }
        public RegistroUsuario? RegistroUsuario { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
