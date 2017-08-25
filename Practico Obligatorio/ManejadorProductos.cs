using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    class ManejadorProductos
    {
        private static ManejadorProductos instance;
        private List<Producto> Lista_Productos = new List<Producto>();
        int identificador = 0;
        private ManejadorProductos() { }
        public static ManejadorProductos Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManejadorProductos();
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


        public void AgregarProducto()
        {
            bool ingresarDeNuevo = true;
            Producto producto = new Producto();
            while (ingresarDeNuevo)
            {
                try
                {
                    Console.Write("Nombre: ");
                    var nombre = Console.ReadLine();
                    int number;
                    if ((int.TryParse(nombre, out number)) || (nombre == ""))
                    {
                        throw new Exception();
                    }
                    producto.nombre = nombre;
                    ingresarDeNuevo = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El nombre no puede ser vacio o un numero" + "\n");
                    Console.ResetColor();
                }

            }
            ingresarDeNuevo = true;
            while (ingresarDeNuevo)
            {
                try
                {
                    Console.Write("Marca: ");
                    var marca = Console.ReadLine();
                    int number;
                    if ((int.TryParse(marca, out number)) || (marca == ""))
                    {
                        throw new Exception();
                    }
                    producto.marca = marca;
                    ingresarDeNuevo = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La marca no puede ser vacio o un numero" + "\n");
                    Console.ResetColor();
                }

            }
            ingresarDeNuevo = true;
            while (ingresarDeNuevo)
            {
                try
                {
                    Console.Write("Precio: ");
                    var precio = Console.ReadLine();
                    if (IsDigitsOnly(precio))
                    {
                        int precioValido = Convert.ToInt32(precio);
                        if (precioValido > 0)
                        {
                            producto.precio = precioValido;
                            ingresarDeNuevo = false;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }

                    else
                    {
                        throw new Exception();
                    }

                    ingresarDeNuevo = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El precio tiene que ser un entero positivo" + "\n");
                    Console.ResetColor();


                }

            }

            ingresarDeNuevo = true;
            while (ingresarDeNuevo)
            {
                try
                {
                    Console.Write("Stock inicial: ");
                    var stock = Console.ReadLine();
                    if (IsDigitsOnly(stock))
                    {
                        int stockValido = Convert.ToInt32(stock);
                        if (stockValido > 0)
                        {
                            producto.stock = stockValido;
                            ingresarDeNuevo = false;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }

                    else
                    {
                        throw new Exception();
                    }

                    ingresarDeNuevo = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La cantidad de stock tiene que ser un entero positivo" + "\n");
                    Console.ResetColor();


                }

            }
            producto.codigo_identificacion = identificador;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Producto creado con el codigo " + identificador + "\n");
            Console.ResetColor();
            Lista_Productos.Add(producto);
            identificador++;
        }

        public void AltaStock()
        {
            for (int indice = 0; indice < Lista_Productos.Count; indice++)
            {
                Lista_Productos[indice].imprimirProducto();
            }
            var ingresarDeNuevo = true;
            while(ingresarDeNuevo)
            {
                try
                {
                    Console.WriteLine("Ingrese id para agregar stock o enter para volver al menu");
                    var productoValido = Console.ReadLine();

                    if (string.IsNullOrEmpty(productoValido))
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
                        Console.Write("Cantidad del producto ingresado:");
                        var stockProducto = (Console.ReadLine());
                        if (IsDigitsOnly(stockProducto))
                        {
                            if (Convert.ToInt32(stockProducto) > 0)
                            {
                                if (productoIngresado.stock >= Convert.ToInt32(stockProducto))
                                {
                                    var stockAComprar = Convert.ToInt32(stockProducto);
                                    productoIngresado.stock += stockAComprar;
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

                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El id ingresado no existe" + "\n");
                    Console.ResetColor();
                }
            }


        }

        public void InformeStock()
        {
            if (ExistenProductos())
            {
                for (int indice = 0; indice < Lista_Productos.Count; indice++)
                {
                    Lista_Productos[indice].imprimirProducto();
                }
            }
            else
            {
                Console.WriteLine("No hay ningun producto registrado");
            }
        
        }

        public Producto BuscarProducto(string productoValido)
        {
            return Lista_Productos.Find(x => x.codigo_identificacion == Convert.ToInt32(productoValido));
        }               

        public bool ExistenProductos()
        {
            return Lista_Productos.Count > 0;
        }
    }
}
