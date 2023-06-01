using FindServicesApp_BackEnd.Shared.Models.contrato;
using FindServicesApp_BackEnd.Shared.Models.plan_servicios;
using FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad;
using FindServicesApp_BackEnd.Shared.Models.Profesiones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.usuario
{
    public class RegistroUsuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El Campo Correo es Obligatorio.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "* El Campo Contraseña es Obligatorio.")]

        //[StringLength(15, MinimumLength = 4,
        //          ErrorMessage = "* La Contraseña debe tener Max. 4 y Min. 15 Caracteres.")]
        [StringLength(200)]
        [MinLength(length: 10, ErrorMessage = "* La Contraseña debe tener Max. 10 Caracteres")]
        [MaxLength(length: 20, ErrorMessage= "* La Contraseña debe tener Min. 20 Caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "* Seleccione Un Tipo de Usuario.")]

        //roles
        public int? id_roll { get; set; }

        public Roll? Roll { get; set; }

        //Datos General parte inicial
        public DatosGenerales?  DatosGenerales { get; set; }


        //Datos Generales parte final
        public DatoGeneralesFinal? DatosGeneralesFinal { get; set; }

        //firma
        public FirmaContrato? firma { get; set; }

        //contrato
        public int? id_contrato { get; set; }
        public Contrato? Contrato { get; set; }

        //este campo llamado contrato_aprobado sera un true o false
        //tiene que ser true para ser aprobado
        public bool? Contrato_aprobado { get; set; } = false;

        //en este campo el admin 
        public bool contrato_firmado { get; set; } = false;

        //planes de categorias
        public int? id_categoria_planes { get; set; }
        public Categoria_planes? categoria_planes { get; set; }

        //pregunta_seguridad
        public Pregunta_Contestadas? Pregunta_Contestadas { get; set; }
 

        //este campo podria servir para Activo o Inactivar usuarios
        public string? Activo { get; set; } = "Activo";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
