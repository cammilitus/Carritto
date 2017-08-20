using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    public class Cliente
    {
        public string nombre{ get; set; }
        public int cedula_Rut { get; set; }
        public string domicilio { get; set; }
        public DateTime fecha_Nacimiento { get; set; }
        public void imprimirCliente()
        {
            Console.WriteLine("Nombre: " + this.nombre);
            Console.WriteLine("CI o RUT" + this.cedula_Rut);
            Console.WriteLine("Domicilio " + this.domicilio);
            Console.WriteLine("Fecha de Nacimiento: " + this.fecha_Nacimiento.ToShortDateString());

            Console.WriteLine();
        }





    }
}
