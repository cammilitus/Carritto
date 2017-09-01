using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Practico_Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema.Instance.CrearAdmin();
            var programaCorriendo = true;    
            string opcionMenu;            
            while (programaCorriendo)
            {                
                if(ManejadorPersona.Instance.nombreUsuarioLogueado == "")
                {
                    var ingresarDeNuevo = true;
                    while (ingresarDeNuevo)
                    {                        
                        ingresarDeNuevo = Sistema.Instance.Login();
                    }
                }              
                
                Sistema.Instance.MenuPrincipal();
                opcionMenu = Console.ReadLine();
                var opcionChar = opcionMenu.ToCharArray();
                if ((opcionMenu != "") && (Char.IsNumber(opcionChar[0])))
                {
                    switch (Convert.ToInt32(opcionMenu))
                    {
                        //Menu de registro
                        case 1:                        
                            Sistema.Instance.MenuRegistro();
                            opcionMenu = Console.ReadLine();
                            var opcionChar1 = opcionMenu.ToCharArray();
                            if ((opcionMenu != "") && (Char.IsNumber(opcionChar1[0])))
                            {
                                switch (Convert.ToInt32(opcionMenu))
                                {
                                    case 1:
                                        Sistema.Instance.Logout();
                                        break;
                                    case 2:                                        
                                        Sistema.Instance.AgregarFactura();
                                        break;
                                    case 3:
                                        Sistema.Instance.AgregarProducto();
                                        break;
                                    case 4:
                                        Sistema.Instance.AltaStock();
                                        break;
                                    case 5:
                                        if (ManejadorPersona.Instance.esAdmin)
                                        {
                                            Sistema.Instance.AgregarVendedor();
                                        }
                                        break;
                                    case 6:
                                        if (ManejadorPersona.Instance.esAdmin)
                                        {
                                            Sistema.Instance.AgregarCliente();
                                        }
                                        break;                                   
                                }
                               
                            }
                            break;
                        case 2:
                            //Menu de listado
                            Sistema.Instance.MenuListar();
                            opcionMenu = Console.ReadLine();
                            opcionChar1 = opcionMenu.ToCharArray();
                            if ((opcionMenu != "") && (Char.IsNumber(opcionChar1[0])))
                            {
                                switch (Convert.ToInt32(opcionMenu))
                                {
                                    case 1:
                                        Sistema.Instance.ListarCLientes();
                                        break;
                                    case 2:
                                        Sistema.Instance.ListarFacturas();
                                        break;
                                    case 3:
                                        Sistema.Instance.InformeStock();
                                        break;
                                    case 4:
                                        Sistema.Instance.ListarPersonas();
                                        break;
                                }
                            }
                            break;
                        case 3:
                            Sistema.Instance.Logout();
                            break;
                        default:
                            Console.WriteLine("Debe ingresar 1 para menu de registro o 2 para menu de listado");
                            break;
                    }
                }
            }
        }
    }
}
