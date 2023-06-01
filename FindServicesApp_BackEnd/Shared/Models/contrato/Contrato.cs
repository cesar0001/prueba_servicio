using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.contrato
{
    public class Contrato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* El Campo Contrato es Obligatorio.")]
        [MaxLength(2000000, ErrorMessage= "* Solo puede Escribir Max. 2000000 Caracetes.")]
        public string contrato { get; set; }

        public string status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}
