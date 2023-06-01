using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.eduacion
{
    public class Educacion
    {
        public int Id { get; set; }

        public int RegistroUsuarioId { get; set; }
        public RegistroUsuario? RegistroUsuario { get; set; }

        [Required(ErrorMessage = "* El Campo Titulo es Obligatorio.")]
        [MaxLength(250, ErrorMessage = "* Solo puede Escribir Max. 250 Caracetes.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "* El Campo Centro de Estudio es Obligatorio.")]
        [MaxLength(250, ErrorMessage = "* Solo puede Escribir Max. 250 Caracetes.")]
        public string Centro_Estudio { get; set; }

        [Required(ErrorMessage = "* Este Campo es Obligatorio.")]
        [MaxLength(100, ErrorMessage = "* Solo puede Escribir Max. 100 Caracetes.")]
        public string Modalidad_Estudio { get; set; }

        [Required(ErrorMessage = "* Este Campo es Obligatorio.")]
        [MaxLength(100, ErrorMessage = "* Solo puede Escribir Max. 100 Caracetes.")]
        public string Nivel_Estudio { get; set; }

        [Required(ErrorMessage = "* El Campo Municipio es Obligatorio.")]
        public int MunicipioId { get; set; } = 0;
        public Municipio? Estado { get; set; }

        [Required(ErrorMessage = "* El Campo Departamento es Obligatorio.")]
        public int DepartamentoId { get; set; } = 0;
        public Departamentos? Departamento { get; set; }

        [Required(ErrorMessage = "* El Campo Desde es Obligatorio.")]
        [DataType(DataType.DateTime, ErrorMessage = "* El campo Desde debe ser una Fecha válida.")]
        public DateTime Desde { get; set; }

        //[Required(ErrorMessage = "* El Campo Hasta es Obligatorio.")]
        public string? Hasta { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }


    }
}
