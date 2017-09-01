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

        //Login
        public bool Login()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Carritto");
            return ManejadorPersona.Instance.LoginUsuario();
        }   

        public void Logout()
        {
            ManejadorPersona.Instance.Logout();
        }
                
        //ImpresionMenu
        public void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("1. Menu de registro ");
            Console.WriteLine("2. Menu de listado");
            Console.WriteLine("3. Salir");
        }

        public void MenuRegistro()
        {
            Console.Clear();
            Console.WriteLine("Menu de registro:");
            Console.WriteLine("1.Salir");
            Console.WriteLine("2.Registrar Factura ");
            Console.WriteLine("3.Registrar Producto"); 
            Console.WriteLine("4.Alta de Stock");
            if (ManejadorPersona.Instance.esAdmin)
            {
                Console.WriteLine("5.Registrar Vendedor ");
                Console.WriteLine("6.Registrar Cliente ");
            }
        }        

        public void MenuListar()
        {
            Console.Clear();
            Console.WriteLine("\n" + "Menu de Listado:" + "\n");
            Console.WriteLine("1.Listar Clientes ");
            Console.WriteLine("2.Listar Facturas");
            Console.WriteLine("3.Informe de Stock");
            Console.WriteLine("4.Listar Personas");
        }

        //Metodos de Clientes
        public void AgregarCliente()
        {
            ManejadorPersona.Instance.AgregarCliente();
        }

        public void AgregarVendedor()
        {
            ManejadorPersona.Instance.AgregarVendedor();
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

        public void ListarPersonas()
        {
            ManejadorPersona.Instance.ImprimirPersonas();
        }

        //Metodos de Facturas
        public void AgregarFactura()
        {
            if ((ManejadorPersona.Instance.ExistenClientes()) && (ManejadorProductos.Instance.ExistenProductos()))
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
        public void InformeStock()
        {
            ManejadorProductos.Instance.InformeStock();
        }

        public void AltaStock()
        {
            if (ManejadorProductos.Instance.ExistenProductos())
            {
                ManejadorProductos.Instance.AltaStock();
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
