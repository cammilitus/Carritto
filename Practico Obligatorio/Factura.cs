using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    class Factura
    {
        public DateTime fecha;
        public Persona cliente;
        public string usuarioLogueado;
        public List<int> listaCantidadProducto;
        public List <Producto> lista_productos;
        public void imprimirFactura()
        {
            Console.WriteLine("Fecha : " + this.fecha.ToShortDateString());
            Console.WriteLine("Cliente: " + this.cliente.nombre);
            Console.WriteLine("CI o RUT: " + this.cliente.cedula_Rut);          
            Console.WriteLine("Vendedor: " + this.usuarioLogueado);
            Console.WriteLine("Monto total: $" + this.calcularMonto());
            Console.WriteLine();
        }
        public int calcularMonto()
        {
            int montoTotal = 0;
            for (int indice = 0; indice < lista_productos.Count; indice++)
            {
                montoTotal += lista_productos[indice].precio * listaCantidadProducto[indice];
            }
            return montoTotal;
        }
        public Factura()
        {
            listaCantidadProducto = new List<int>();
            lista_productos = new List<Producto>();
        }


    }
}
