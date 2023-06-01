using FindServicesApp_BackEnd.Shared.Dto.firmaDto;
using FindServicesApp_BackEnd.Shared.Models.eduacion;
using FindServicesApp_BackEnd.Shared.Models.experiencia_laboral;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.usuarioDto
{
    public class DatoGeneralesFinalDto
    {
        public int Id { get; set; }

 
        public string? foto_perfil { get; set; }

        public string? foto_identidad_trasera { get; set; }

        public string? foto_identidad_adelantera { get; set; }

        public int RegistroUsuarioId { get; set; }
        public RegistroUsuario? RegistroUsuario { get; set; }

        public List<Experiencia_Laboral>? Experiencia_Laboral { get; set; }

        public List<Educacion>? Educacion_listado { get; set; }

        public ImagenLocal? Imagen_perfil { get; set; } = new ImagenLocal();
        public ImagenLocal? Imagen_identidad_delantera { get; set; } = new ImagenLocal();
        public ImagenLocal? Imagen_identidad_trasera { get; set; } = new ImagenLocal();


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
