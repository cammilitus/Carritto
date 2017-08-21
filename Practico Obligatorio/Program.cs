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
            var programaCorriendo = true;    
            string opcionMenu;            
            while (programaCorriendo)
            {
               // Sistema.Ingresocontrasenia();
                Sistema.Instance.CrearAdmin();
                Sistema.Instance.MenuPrincipal();
                opcionMenu = Console.ReadLine();
                var opcionChar = opcionMenu.ToCharArray();
                if ((opcionMenu != "") && (Char.IsNumber(opcionChar[0])))
                {
                    switch (Convert.ToInt32(opcionMenu))
                    {
                        //Menu de registro
                        case 1:
                            Sistema.Instance.MenuRegistroAdmin();
                        opcionMenu = Console.ReadLine();
                        var opcionChar1 = opcionMenu.ToCharArray();
                        if ((opcionMenu != "") && (Char.IsNumber(opcionChar1[0])))
                        {
                                switch (Convert.ToInt32(opcionMenu))
                                {
                                    //registrar Cliente
                                    case 1:
                                        Sistema.Instance.AgregarCliente();                                   
                                        break;
                                    case 2:
                                        //Ingreso de factura
                                        Sistema.Instance.AgregarFactura();
                                        break;
                                    case 3:
                                        Sistema.Instance.AgregarProducto();
                                        break;
                                }
                               
                        }
                            break;
                        case 2:
                            Sistema.Instance.MenuListar();
                            opcionMenu = Console.ReadLine();
                            switch(Convert.ToInt32(opcionMenu))
                            {
                                case 1:
                                    Sistema.Instance.ListarCLientes();
                                    break;
                                case 2:
                                    Sistema.Instance.ListarFacturas();
                                    break;
                                case 3:
                                    Sistema.Instance.ListarProductos();
                                    break;

                            }
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
