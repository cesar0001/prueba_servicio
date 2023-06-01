using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad
{
    public class Pregunta_Contestadas
    {
        public int Id { get; set; }

        public string? respuesta { get; set; }

        //guardo el id de la pregunta
        public int PreguntaSeguridadId { get; set; }
        public Pregunta_Seguridad? PreguntaSeguridad { get; set; }

        //registra el id del usuario
        public int RegistroUsuarioId { get; set; }
        public RegistroUsuario? RegistroUsuario { get; set; }

        //
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
