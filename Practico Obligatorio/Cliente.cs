using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    public class Cliente : Persona
    {
        public string domicilio { get; set; }        
        public override void ImprimirPersona()
        {
            Console.WriteLine("Nombre: " + this.nombre);
            Console.WriteLine("CI o RUT" + this.cedula_Rut);
            Console.WriteLine("Domicilio " + this.domicilio);    
            
        }        
    }
}
