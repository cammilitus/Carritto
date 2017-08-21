using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    class Producto
    {
        public string nombre;
        public string marca;
        public int codigo_identificacion;
        public int precio;
        public int stock;
        public void imprimirProducto()
        {
            System.Console.WriteLine("Nombre : " + this.nombre);
            System.Console.WriteLine("Marca: " + this.marca);
            System.Console.WriteLine("Id: " + this.codigo_identificacion);
            System.Console.WriteLine("Precio: $" + this.precio);


            System.Console.WriteLine();
        }
    }
}
