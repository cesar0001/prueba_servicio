 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Dto.firmaDto
{
    public class FirmaCreateOrEditDto
    {
        public int idUsuario { get; set; }

        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
