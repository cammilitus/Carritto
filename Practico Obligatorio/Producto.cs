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
            Console.WriteLine("Nombre : " + this.nombre);
            Console.WriteLine("Marca: " + this.marca);
            Console.WriteLine("Id: " + this.codigo_identificacion);
            Console.WriteLine("Precio: $" + this.precio);
            Console.WriteLine("Stock: " + this.stock);

        }
    }
}
