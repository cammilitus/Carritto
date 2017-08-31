using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    class Vendedor : Persona
    {
        public string telefono { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }

        public override void ImprimirPersona()
        {
            Console.WriteLine("Nombre: " + this.nombre);
            Console.WriteLine("CI o RUT" + this.cedula_Rut);
            Console.WriteLine("Telefono " + this.telefono);
           
        }
    }
}
