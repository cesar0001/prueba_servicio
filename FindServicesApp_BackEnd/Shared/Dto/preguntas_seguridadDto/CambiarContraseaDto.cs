using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.preguntas_seguridadDto
{
    public class CambiarContraseaDto
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "* Este Campo es Obligatorio.")]
        [StringLength(20, MinimumLength = 10,
                  ErrorMessage = "* La Contraseña debe tener Max. 10 y Min. 20 Caracteres.")]
        public string ClaveNueva { get; set; }

        [Required(ErrorMessage = "* Este Campo es Obligatorio.")]
        [Compare("ClaveNueva", ErrorMessage = "Las Contraseñas no Coinciden.")]
        public string RepetirClave { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
