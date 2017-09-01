using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    public class Persona
    {
        public string nombre { get; set; }
        public long cedula_Rut { get; set; }
        public DateTime fecha_Nacimiento { get; set; }

        public virtual void ImprimirPersona()
        {
            
        }
    }

    
}
