using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities

{
    public class Cliente: AuditableBaseEntity
    {
        private int edad { get; set; }
         public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        
        public string telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }


       public int Edad {
            get {
                if (this.edad <= 0)
                {


                    this.edad = new DateTime(DateTime.Now.Subtract(this.fecha_nacimiento).Ticks).Year - 1;

                }
                 return this.edad;
            
            
            }
            set { this.edad = value; }
        
        
        }
    }
}
