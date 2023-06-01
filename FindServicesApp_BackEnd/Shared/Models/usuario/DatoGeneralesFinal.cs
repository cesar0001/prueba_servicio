using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.experiencia_laboral;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.usuario
{
    public class DatoGeneralesFinal
    {
        public int Id { get; set; }
 
        public string? foto_perfil { get; set; }

        public string? foto_identidad_trasera { get; set; }

        public string? foto_identidad_adelantera { get; set; }

        public int RegistroUsuarioId { get; set; }
        public RegistroUsuario? RegistroUsuario { get; set; }

 
        public List<Experiencia_Laboral>? Experiencia_Laboral { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
