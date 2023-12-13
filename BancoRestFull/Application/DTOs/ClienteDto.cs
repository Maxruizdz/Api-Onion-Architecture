using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ClienteDto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }


        public int Edad { get; set; }
        public string telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }


        
    }
}
