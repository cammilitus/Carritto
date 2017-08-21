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
        public List<int> listaCantidadProducto;
        public List <Producto> lista_productos;
        public void imprimirFactura()
        {
            System.Console.WriteLine("Fecha : " + this.fecha.ToShortDateString());
            System.Console.WriteLine("Cliente: " + this.cliente.nombre);
            System.Console.WriteLine("CI o RUT: " + this.cliente.cedula_Rut);
            System.Console.WriteLine("Monto total: $" + this.calcularMonto());

            System.Console.WriteLine();
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
