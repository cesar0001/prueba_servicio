using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.usuarioDto
{
    public class existeCorreoDto
    {
        [Required(ErrorMessage = "* El campo Correo  es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
