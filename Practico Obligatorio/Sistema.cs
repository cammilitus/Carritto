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

        public static string Ingresocontrasenia()
        {
            Console.WriteLine("Ingrese Usuario:");
            string usuario = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña:");
            string contrasenia = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    contrasenia += info.KeyChar;
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(contrasenia))
                    {
                        contrasenia = contrasenia.Substring
                        (0, contrasenia.Length - 1);
                    }
                    info = Console.ReadKey(true);
                }
            }
            for (int i = 0; i < contrasenia.Length; i++)
                Console.Write("*");
            return contrasenia;
        }
        //ImpresionMenu
        public void MenuLoginAdmin()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Carritto" );
            Console.Write("Ingrese usuario:");
        }    

        public void MenuPrincipal()
        {
            Console.WriteLine("1. Menu de registro ");
            Console.WriteLine("2. Menu de listado" + "\n");
        }

        public void MenuRegistroAdmin()
        {
            Console.Clear();
            Console.WriteLine("Menu de registro:");
            Console.WriteLine("1.Registrar Vendedor ");
            Console.WriteLine("2.Registrar Cliente ");
            Console.WriteLine("3.Registrar Factura ");
            Console.WriteLine("4.Registrar Producto"); 
            Console.WriteLine("5.Alta de Stock");
            Console.WriteLine("6.Salir");
        }

        public void MenuRegistroVendedor()
        {
            Console.Clear();
            Console.WriteLine("\n" + "Menu de registro:" + "\n");            
            Console.WriteLine("1.Registrar Factura ");
            Console.WriteLine("2.Registrar Producto" + "\n"); 
            Console.WriteLine("2.Alta de Stock");
            Console.WriteLine("4.Salir");
        }

        public void MenuListar()
        {
            Console.Clear();
            Console.WriteLine("\n" + "Menu de Listado:" + "\n");
            Console.WriteLine("1.Listar Clientes ");
            Console.WriteLine("2.Listar Facturas");
            Console.WriteLine("3.Listar Productos" + "\n");
            Console.WriteLine("4.Informe de Stock");
            Console.WriteLine("5.Listar Personas");
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
