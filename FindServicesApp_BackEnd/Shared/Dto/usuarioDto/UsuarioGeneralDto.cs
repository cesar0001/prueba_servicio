using FindServicesApp_BackEnd.Shared.Models.contrato;
using FindServicesApp_BackEnd.Shared.Models.plan_servicios;
using FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.usuarioDto
{
    public class UsuarioGeneralDto
    {
        public int Id { get; set; }
 
        public string Email { get; set; }
 
        public string Password { get; set; }

 

        //roles
        public int? id_roll { get; set; }

        public Roll? Roll { get; set; }

        //Datos General parte inicial
        public DatosGenerales? DatosGenerales { get; set; }


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

        public int cantidad_experiencia_lab { get; set; } = 0;

        public int cantidad_educacion { get; set; } = 0;

        //este campo podria servir para Activo o Inactivar usuarios
        public string? Activo { get; set; } = "Activo";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
