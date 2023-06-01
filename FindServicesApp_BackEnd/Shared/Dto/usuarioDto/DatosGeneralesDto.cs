using FindServicesApp_BackEnd.Shared.Dto.firmaDto;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.Profesiones;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.usuarioDto
{
    public class DatosGeneralesDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El Campo Nombre es Obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "* El Campo Apellido es Obligatorio.")]
        public string Apellido { get; set; }

        //[Required(ErrorMessage = "* El Campo Profesion es Obligatorio.")]
        //public string Profesion { get; set; }
        [Required(ErrorMessage = "* Seleccione una Profesion.")]
        //profesion
        public int? id_profesion { get; set; }
        public Profesion? Profesion { get; set; }

        [Required(ErrorMessage = "* El Campo Identidad es Obligatorio.")]
        public string Identidad { get; set; }

        [Required(ErrorMessage = "* El Campo Fecha de Nacimiento es Obligatorio.")]
        public DateTime Fecha_nacimiento { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "* El Campo Genero es Obligatorio.")]
        public string Genero { get; set; }

        //[Required(ErrorMessage = "* El Campo Acerca de es Obligatorio.")]
        //[NoEmailOrNumber(ErrorMessage = "La propiedad no debe contener correos o números")]
        public string? Opinion_Personal { get; set; }

        public int RegistroUsuarioId { get; set; }
        public RegistroUsuario? RegistroUsuario { get; set; }

        [Required(ErrorMessage = "* El Campo Municipio es Obligatorio.")]
        public int MunicipioId { get; set; } = 0;
        public Municipio? Estado { get; set; }

        public int DepartamentoId { get; set; } = 0;
        public Departamentos? departamentos { get; set; }

        public string? foto_personal { get; set; }

        [Required(ErrorMessage = "* El Campo Celular es Obligatorio.")]
        public string Celular { get; set; }

        public string? Telefono { get; set; }

        [Required(ErrorMessage = "* El Campo Direccion es Obligatorio.")]
        [MaxLength(1000, ErrorMessage = "* Solo puede Escribir Max. 1000 Caracetes.")]
        public string Direccion { get; set; }

        public string? Facebook { get; set; }

        public string? Instagram { get; set; }

        public string? sacar_id_profesional { get; set; }

        public string? latitud { get; set; }

        public string? longitud { get; set; }

        //esta variable no se crea en la tabla es solo para traer info de imagen        
        public ImagenLocal? Imagen { get; set; } = new ImagenLocal();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
