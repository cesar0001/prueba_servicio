using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.preguntas_seguridadDto
{
    public class PreguntasSeguridadDto
    {
        
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "* Este Campo es Obligatorio")]
        public string idPreguntaSeguridad { get; set; }

        [Required(ErrorMessage = "* Este Campo es Obligatorio")]
        public string respuesta { get; set;}
    }
}
