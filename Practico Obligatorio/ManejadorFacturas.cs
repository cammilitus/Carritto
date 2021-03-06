﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    class ManejadorFacturas
    {
        private static ManejadorFacturas instance;
        private List<Factura> Lista_Facturas = new List<Factura>();
        private ManejadorFacturas() { }
        public static ManejadorFacturas Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManejadorFacturas();
                }
                return instance;
            }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public void AgregarFactura()
        {
            bool fechavalida = false;
            Factura factura = new Factura();
            do
            {
                try
                {
                    Console.WriteLine("Ingrese fecha de la factura DD/MM/AAAA");

                    factura.fecha = DateTime.Today;
                    factura.fecha = Convert.ToDateTime(Console.ReadLine());
                    fechavalida = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, la fecha o el formato no son correctos." + "\n");
                    Console.ResetColor();
                    fechavalida = false;
                }
            } while (!fechavalida);

            Console.WriteLine("Ingrese CI o RUT : ");
            bool ingresarDeNuevo = true;
            while (ingresarDeNuevo)
            {
                var id = Console.ReadLine();
                try
                {
                    if ((id != "") && (IsDigitsOnly(id)))
                    {
                        var usarCI = ManejadorPersona.Instance.BuscarCliente(id);
                        if (usarCI == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El cliente de CI o RUT " + id + " no existe \n");
                            Console.ResetColor();
                            ingresarDeNuevo = true;
                        }
                        else
                        {
                            factura.cliente = usarCI;
                            ingresarDeNuevo = false;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato incorrecto");
                    Console.ResetColor();
                }
            }


            var esPrimerProducto = true;
            ingresarDeNuevo = true;
            while (ingresarDeNuevo)
            {
                Console.Write("Ingrese id del producto o enter para finalizar:");

                var productoValido = Console.ReadLine();
                try
                {
                    if ((!esPrimerProducto) && (string.IsNullOrEmpty(productoValido)))
                    {
                        ingresarDeNuevo = false;
                    }
                    else
                    {
                        var productoIngresado = ManejadorProductos.Instance.BuscarProducto(productoValido);
                        if (productoIngresado == null)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            var ingresarCantidadDeNuevo = true;
                            while (ingresarCantidadDeNuevo)
                            {
                                Console.Write("Cantidad del producto ingresado:");
                                var stockProducto = (Console.ReadLine());
                                if (IsDigitsOnly(stockProducto))
                                {
                                    if (Convert.ToInt32(stockProducto) > 0)
                                    {
                                        if (productoIngresado.stock >= Convert.ToInt32(stockProducto))
                                        {
                                            var stockAComprar = Convert.ToInt32(stockProducto);
                                            factura.listaCantidadProducto.Add(stockAComprar);
                                            factura.lista_productos.Add(productoIngresado);
                                            productoIngresado.stock -= stockAComprar;
                                            ingresarCantidadDeNuevo = false;
                                            esPrimerProducto = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("El stock disponible es " + productoIngresado.stock);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Debe ingresar un entero mayor a cero" + "\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Debe ingresar un entero mayor a cero" + "\n");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El id ingresado no existe" + "\n");
                    Console.ResetColor();
                }
            }

            factura.usuarioLogueado = ManejadorPersona.Instance.nombreUsuarioLogueado;
            Lista_Facturas.Add(factura);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Factura ingresada exitosamente" + "\n");
            Console.ResetColor();
        }

       
        public void ImprimirFactura()
        {
            for (int indice = 0; indice < Lista_Facturas.Count; indice++)
            {
                Lista_Facturas[indice].imprimirFactura();
            }

        }
        public bool ExistenFacturas()
        {
            return Lista_Facturas.Count > 0;
        }
    }
}
