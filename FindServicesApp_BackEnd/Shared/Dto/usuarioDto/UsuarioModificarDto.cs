using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.usuarioDto
{
    public class UsuarioModificarDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El Campo Correo Electronico es Obligatorio.")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required(ErrorMessage = "* El Campo Clave Actual es Obligatorio.")]
        [StringLength(20, MinimumLength = 10,
                  ErrorMessage = "* La Contraseña debe tener Max. 10 y Min. 20 Caracteres.")]
        public string ContraseñaActual { get; set; }

        [Required(ErrorMessage = "* El Campo Nueva Contraseña es Obligatorio.")]
        [StringLength(20, MinimumLength = 10,
                  ErrorMessage = "* La Contraseña debe tener Max. 10 y Min. 20 Caracteres.")]
        public string ContraseñaNueva { get; set; }

        [Required(ErrorMessage = "* El Campo Confirmar Nueva Contraseña es Obligatorio.")]
        [Compare("ContraseñaNueva", ErrorMessage = "Las Contraseñas no Coinciden.")]
        public string ConfirmarContraseña { get; set; }

    }
}