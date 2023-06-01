using FindServicesApp_BackEnd.Shared.Dto.preguntas_seguridadDto;
using FindServicesApp_BackEnd.Shared.Models.eduacion;
using FindServicesApp_BackEnd.Shared.Models.experiencia_laboral;
using FindServicesApp_BackEnd.Shared.Models.plan_servicios;
using FindServicesApp_BackEnd.Shared.Models.Profesiones;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models
{
    public class Respuesta
    {
        public string? res { get; set; } = null;
        public string? otro { get; set; } = null;
        public string? ids { get; set; } = null;
        public string? contratos { get; set; } = null;
        public string? token { get; set; } = null;

        public recuperando_claveDto? modelo { get; set; }

        public Profesion? modelo_pro { get; set; }

        public Experiencia_Laboral? experiencia_lab { get; set; }

        public Educacion? modelo_educacion { get; set; }

    }
}
