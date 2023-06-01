using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.preguntas_seguridadDto
{
    public class recuperando_claveDto
    {
        public int idUsuario { get; set; }

        public int? idPreguntaSeguridad { get; set; }
        public string? miPregunta { get; set; }

        public string? miRespuesta { get; set; }

        [Required(ErrorMessage = "* Este Campo es Obligatorio")]
        public string respuesta { get; set; }
    }
}
