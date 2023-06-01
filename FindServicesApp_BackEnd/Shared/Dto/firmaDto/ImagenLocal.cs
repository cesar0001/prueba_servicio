using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.firmaDto
{
    public class ImagenLocal
    {
        public int Id { get; set; } // clave principal

        public string? FileName { get; set; } = null;
        public byte[]? FileContent { get; set; } = null;
        public long? tamaño { get; set; } = 0;
        //usamos esHttp si es true cuando se quiera modificar imagen no lo va hacer ahora si es false porque puede ser que se tenga la imagen del servidor
        public bool? esHttp { get; set; }
    }
}
