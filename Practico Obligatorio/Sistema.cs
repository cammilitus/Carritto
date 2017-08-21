using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    class Sistema
    {
        private static Sistema instance;        
        private Sistema() { }
        public static Sistema Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sistema();
                }
                return instance;
            }
        }

        public void CrearAdmin()
        {
            ManejadorPersona.Instance.CrearAdmin();
        }
        //ImpresionMenu
        public void MenuPrincipal()
        {
            Console.WriteLine("\n" + "Programa de Facturacion" + "\n");
            Console.WriteLine("1. Menu de registro ");
            Console.WriteLine("2. Menu de listado" + "\n");
        }

        public void MenuRegistro()
        {
            Console.WriteLine("\n" + "Menu de registro:" + "\n");
            Console.WriteLine("1.Registrar Cliente ");
            Console.WriteLine("2.Registrar Factura ");
            Console.WriteLine("3.Registrar Producto" + "\n");            
        }

        public void MenuListar()
        {
            Console.WriteLine("\n" + "Menu de Listado:" + "\n");
            Console.WriteLine("1.Listar Clientes ");
            Console.WriteLine("2.Listar Facturas");
            Console.WriteLine("3.Listar Productos" + "\n");
        }

        //Metodos de Clientes
        public void AgregarCliente()
        {
            ManejadorPersona.Instance.AgregarCliente();
        }
        
        public void ListarCLientes()
        {
            if (ManejadorPersona.Instance.ExistenClientes())
            {
                ManejadorPersona.Instance.ImprimirPersonas();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ningun Cliente registrado en el sistema" + "\n");
                Console.ResetColor();
            }
        }

        //Metodos de Facturas
        public void AgregarFactura()
        {
            if (ManejadorPersona.Instance.ExistenClientes() && ManejadorProductos.Instance.ExistenProductos())
            {
                ManejadorFacturas.Instance.AgregarFactura();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Debe existir al menos un cliente y un producto para crear una factura" + "\n");
                Console.ResetColor();
            }
        }

        public void ListarFacturas()
        {
            if (ManejadorFacturas.Instance.ExistenFacturas())
            {
                ManejadorFacturas.Instance.ImprimirFactura();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ninguna Factura registrada en el sistema" + "\n");
                Console.ResetColor();
            
            }
        }

        // Metodos de Productos 

        public void AgregarProducto()
        {
            ManejadorProductos.Instance.AgregarProducto();
        }

        public void ListarProductos()
        {
            if (ManejadorProductos.Instance.ExistenProductos())
            {
                ManejadorProductos.Instance.ListarProductos();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay ningun Producto registrado en el sistema" + "\n");
                Console.ResetColor();

            }
        }

    }
}
