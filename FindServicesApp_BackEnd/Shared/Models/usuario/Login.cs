using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.usuario
{
    public class Login
    {
        [Required(ErrorMessage = "* El campo Correo  es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "* El campo Contraseña  es obligatorio")]
        [StringLength(20, MinimumLength = 10,
                  ErrorMessage = "* La Contraseña debe tener Max. 10 y Min. 20 Caracteres.")]
        public string Password { get; set; }
    }
}
