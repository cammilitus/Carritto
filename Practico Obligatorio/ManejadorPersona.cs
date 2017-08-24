using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Obligatorio
{
    class ManejadorPersona
    {
        private static ManejadorPersona instance;
        private List<Persona> Lista_Personas = new List<Persona>();      
        private ManejadorPersona() { }
        public static ManejadorPersona Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManejadorPersona();
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

        public bool CedulaEsValida(int cedula)
        {
            int[] formula = { 2, 9, 8, 7, 6, 3, 4 };
            int suma = 0;
            int guion = 0;
            int aux = 0;
            int[] numero = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            if (cedula.ToString().Length == 8)
            {
                numero[0] = Convert.ToInt32(cedula.ToString()[0].ToString());
                numero[1] = Convert.ToInt32(cedula.ToString()[1].ToString());
                numero[2] = Convert.ToInt32(cedula.ToString()[2].ToString());
                numero[3] = Convert.ToInt32(cedula.ToString()[3].ToString());
                numero[4] = Convert.ToInt32(cedula.ToString()[4].ToString());
                numero[5] = Convert.ToInt32(cedula.ToString()[5].ToString());
                numero[6] = Convert.ToInt32(cedula.ToString()[6].ToString());
                numero[7] = Convert.ToInt32(cedula.ToString()[7].ToString());
            }

            //Para cédulas menores a un millón. 
            else if (cedula.ToString().Length == 7)
            {
                numero[0] = 0;
                numero[1] = Convert.ToInt32(cedula.ToString()[0].ToString());
                numero[2] = Convert.ToInt32(cedula.ToString()[1].ToString());
                numero[3] = Convert.ToInt32(cedula.ToString()[2].ToString());
                numero[4] = Convert.ToInt32(cedula.ToString()[3].ToString());
                numero[5] = Convert.ToInt32(cedula.ToString()[4].ToString());
                numero[6] = Convert.ToInt32(cedula.ToString()[5].ToString());
                numero[7] = Convert.ToInt32(cedula.ToString()[6].ToString());
            }

            suma = (numero[0] * formula[0]) + (numero[1] * formula[1]) + (numero[2] * formula[2]) + (numero[3] * formula[3]) + (numero[4] * formula[4]) + (numero[5] * formula[5]) + (numero[6] * formula[6]);

            for (int i = 0; i < 10; i++)
            {
                aux = suma + i;
                if (aux % 10 == 0)
                {
                    guion = aux - suma;
                    i = 10;
                }
            }

            return numero[7] == guion;
        }

        public void AgregarCliente()
        {
            bool ingresarDeNuevo = true;
            Cliente cliente = new Cliente();
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
                    cliente.nombre = nombre;
                    ingresarDeNuevo = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El nombre no puede ser vacio o un numero");
                    Console.ResetColor();
                }

            }
            var documentoValido = false;
            string documentoCliente;
            while (!documentoValido)
            {
                try
                {
                    Console.Write("Cedula o RUT: ");
                    documentoCliente = Console.ReadLine();
                    if ((documentoCliente != "") && (IsDigitsOnly(documentoCliente)))
                    {
                        var buscarDocumentoCliente = Lista_Personas.Find(x => x.cedula_Rut == Convert.ToInt32(documentoCliente));
                        if (buscarDocumentoCliente == null)
                        {
                            if ((documentoCliente.Length == 8) ||(documentoCliente.Length == 7))
                            {
                                if (CedulaEsValida(Convert.ToInt32(documentoCliente)))
                                {
                                    cliente.cedula_Rut = Convert.ToInt32(documentoCliente);
                                    documentoValido = true;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            else if (documentoCliente.Length == 12)
                            {
                                cliente.cedula_Rut = Convert.ToInt32(documentoCliente);
                                documentoValido = true;
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
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato incorrecto, ingreselo nuevamente" + "\n");
                    Console.ResetColor();
                }

            }
            ingresarDeNuevo = true;
            while (ingresarDeNuevo)
            {
                try
                {
                    Console.Write("Domicilio: ");
                    var domicilio = Console.ReadLine();
                    int number;
                    if ((int.TryParse(domicilio, out number)) || (domicilio == ""))
                    {
                        throw new Exception();
                    }
                    cliente.domicilio = domicilio;
                    ingresarDeNuevo = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El domicilio no puede ser vacio o un numero" + "\n");
                    Console.ResetColor();
                }
            }
            bool fechavalida2 = false;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese fecha de nacimiento con el formato DD/MM/AAAA");
                    var today = DateTime.Today;
                    var fecha_nacimiento = Convert.ToDateTime(Console.ReadLine());
                    var result = (today - fecha_nacimiento);
                    if (result.Days >= 6575)
                    {
                        cliente.fecha_Nacimiento = fecha_nacimiento;
                        fechavalida2 = true;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, la fecha de nacimiento no puede ser menor a 18 años." + "\n");
                        Console.ResetColor();
                        fechavalida2 = false;

                    }

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, la fecha o el formato no son correctos." + "\n");
                    Console.ResetColor();
                    fechavalida2 = false;
                }
            } while (!fechavalida2);
            Lista_Personas.Add(cliente);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cliente ingresado exitosamente" + "\n");
            Console.ResetColor();            
        }

        public void ImprimirPersonas()
        {
            for (int indice = 0; indice < Lista_Personas.Count; indice++)
            {
                Lista_Personas[indice].ImprimirPersona();
            }
        }

        public void AgregarVendedor()
        {
            bool ingresarDeNuevo = true;
            Vendedor vendedor = new Vendedor();
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
                    vendedor.nombre = nombre;
                    ingresarDeNuevo = false;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El nombre no puede ser vacio o un numero");
                    Console.ResetColor();
                }

            }
            var documentoValido = false;
            string documento;
            while (!documentoValido)
            {
                try
                {


                    Console.Write("Cedula o RUT: ");
                    documento = Console.ReadLine();
                    if ((documento != "") && (IsDigitsOnly(documento)))
                    {
                        var buscarDocumento = Lista_Personas.Find(x => x.cedula_Rut == Convert.ToInt32(documento));
                        if (buscarDocumento == null)
                        {
                            if ((documento.Length == 8) || (documento.Length == 7))
                            {
                                if (CedulaEsValida(Convert.ToInt32(documento)))
                                {
                                    vendedor.cedula_Rut = Convert.ToInt32(documento);
                                    documentoValido = true;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
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

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Formato incorrecto, ingreselo nuevamente" + "\n");
                    Console.ResetColor();
                }

            }
            var telefonoValido = false;
            string telefono;
            char[] telefonoArray;
            while (!telefonoValido)
            {
                Console.Write("Telefono: ");
                telefono = Console.ReadLine();
                if (telefono != "")
                {
                    telefonoArray = telefono.ToCharArray();
                    for (int i = 0; i < telefono.Length; i++)
                    {
                        if ((!Char.IsNumber(telefono[i])) && (!Char.IsWhiteSpace(telefono[i])))
                        {
                            Console.WriteLine("Formato incorrecto, ingreselo nuevamente");
                            break;
                        }

                        if (i == telefono.Length - 1)
                        {
                            telefonoValido = true;
                            vendedor.telefono = Convert.ToString(telefono);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Formato incorrecto, ingreselo nuevamente");
                }
            }
            bool fechavalida2 = false;
            do
            {
                try
                {
                    Console.WriteLine("Ingrese fecha de nacimiento con el formato DD/MM/AAAA");
                    var today = DateTime.Today;
                    var fecha_nacimiento = Convert.ToDateTime(Console.ReadLine());
                    var result = (today - fecha_nacimiento);
                    if (result.Days >= 6575)
                    {
                        vendedor.fecha_Nacimiento = fecha_nacimiento;
                        fechavalida2 = true;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, la fecha de nacimiento no puede ser menor a 18 años." + "\n");
                        Console.ResetColor();
                        fechavalida2 = false;

                    }

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, la fecha o el formato no son correctos." + "\n");
                    Console.ResetColor();
                    fechavalida2 = false;
                }
            } while (!fechavalida2);
            Lista_Personas.Add(vendedor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cliente ingresado exitosamente" + "\n");
            Console.ResetColor();
        }

       
        public Persona BuscarCliente(string id)
        {
            return Lista_Personas.Find(x => x.cedula_Rut == Convert.ToInt32(id));
        }

        public bool ExistenClientes()
        {
            return Lista_Personas.Count > 0;
        }

        public void CrearAdmin()
        {
            Vendedor admin = new Vendedor();
            admin.nombre = "Admin";
            admin.cedula_Rut = 53927851;
            admin.telefono = "12345678";
            //admin.fecha_Nacimiento = Convert.ToDateTime(12 / 12 / 98); me tira excepcion
            admin.contraseña = "Contra$en4";
            Lista_Personas.Add(admin);
        }
    }
}
