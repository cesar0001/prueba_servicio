using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindServicesApp_BackEnd.Shared.Models.departamento_municipios
{
    public class Departamentos
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<Municipio> Municipios { get; set; }
    }
}
