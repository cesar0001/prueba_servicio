using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.experiencia_laboral
{
    public class Experiencia_Laboral
    {
        public int Id { get; set; }

        public int RegistroUsuarioId { get; set; }
        public RegistroUsuario? RegistroUsuario { get; set; }
 

        [Required(ErrorMessage = "* El Campo Posicion Laboral es Obligatorio.")]
        [MaxLength(300, ErrorMessage = "* Solo puede Escribir Max. 300 Caracetes.")]
        public string Posicion_Laboral { get; set; }

        [Required(ErrorMessage = "* El Campo Compañia es Obligatorio.")]
        [MaxLength(300, ErrorMessage = "* Solo puede Escribir Max. 300 Caracetes.")]
        public string Compañia { get; set; }


        [Required(ErrorMessage = "* El Campo Salario es Obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El Salario debe ser mayor a cero.")]

        public int Salario { get; set; }

        [Required(ErrorMessage = "* El Campo Municipio es Obligatorio.")]
        public int MunicipioId { get; set; } = 0;
        public Municipio? Estado { get; set; }

        [Required(ErrorMessage = "* El Campo Departamento es Obligatorio.")]
        public int DepartamentoId { get; set; } = 0;
        public Departamentos? Departamento { get; set; }

        [Required(ErrorMessage = "* El Campo Descripcion(Funciones del puesto) es Obligatorio.")]
        [MaxLength(800, ErrorMessage = "* Solo puede Escribir Max. 800 Caracetes.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "* El Campo Desde es Obligatorio.")]
        [DataType(DataType.DateTime, ErrorMessage = "* El campo Desde debe ser una Fecha válida.")]
        public DateTime Desde { get; set; }

        //[Required(ErrorMessage = "* El Campo Hasta es Obligatorio.")]
        public string? Hasta { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }



    }
}
