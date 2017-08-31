using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Practico_Obligatorio
{
    class ManejadorPersona
    {
        private static ManejadorPersona instance;
        private List<Persona> Lista_Personas = new List<Persona>();      
        private ManejadorPersona() { }
        public string nombreUsuarioLogueado = "";
        public bool esAdmin = false;
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
        public bool ExisteNombreUsuario(Persona persona, string usuario)
        {
            Vendedor vendedor = (Vendedor)persona;
            if ((persona.GetType() == typeof(Vendedor)) && (vendedor.usuario == usuario))
            {
                return true;
            }
            return false;
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

        public string LeerContrasenia()
        {
            string contenido = "";
            char ingreso;
            Console.WriteLine();
            do
            {
                ingreso = Console.ReadKey().KeyChar;
                if (ingreso != '\b' && (int)ingreso != 13)
                {
                    Console.Write("\b");
                    Console.Write("*");
                    contenido += ingreso;
                }
                else
                {
                    if (ingreso == '\b' && contenido.Length > 0)
                    {
                        Console.Write(" ");
                        Console.Write("\b");
                        contenido = contenido.Substring(0, contenido.Length - 1);
                    }
                }

            } while ((int)ingreso != 13);
            Console.WriteLine();

            return contenido;
        }

        public bool VerificarContrasenia(string contraseña)
        {
            Regex patronNumerico = new Regex("[0-9]");
            Regex patronAlfabeticoMay = new Regex("[A-Z]");
            Regex patronAlfabeticoMin = new Regex("[a-z]");
            Regex patronSimbolos = new Regex("[^A-Za-z0-9]");
            if (contraseña.Length >= 8)
            {
                return (patronAlfabeticoMay.IsMatch(contraseña) && patronAlfabeticoMin.IsMatch(contraseña) && patronNumerico.IsMatch(contraseña) && patronSimbolos.IsMatch(contraseña));
            }
            else
                return false;
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

        public bool LoginUsuario()
        {
            Console.Write("Ingrese usuario: ");
            var usuario = Console.ReadLine();
            Console.Write("Ingrese contraseña");
            var contrasenia = LeerContrasenia();
            var buscarUsusario = Lista_Personas.Find(x => ExisteNombreUsuario(x, usuario));
            if((buscarUsusario != null) && (((Vendedor)buscarUsusario).contrasenia == contrasenia))
            {
                nombreUsuarioLogueado = ((Vendedor)buscarUsusario).usuario;
                esAdmin = ((Vendedor)Lista_Personas[0]).usuario == usuario;
                return false;
            }

            return true;            
        }

        public void Logout()
        {
            nombreUsuarioLogueado = "";
            esAdmin = false;
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
            ingresarDeNuevo = false;
            string documentoCliente;
            while (ingresarDeNuevo)
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
                                    ingresarDeNuevo = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            else if (documentoCliente.Length == 12)
                            {
                                cliente.cedula_Rut = Convert.ToInt32(documentoCliente);
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
            ingresarDeNuevo = true;
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
                        ingresarDeNuevo = false;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, la fecha de nacimiento no puede ser menor a 18 años." + "\n");
                        Console.ResetColor();                       

                    }

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, la fecha o el formato no son correctos." + "\n");
                    Console.ResetColor();
                   
                }
            } while (ingresarDeNuevo);
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
                Lista_Personas.OrderBy(x => x.cedula_Rut);
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
            ingresarDeNuevo = true;
            string documento;
            while (ingresarDeNuevo)
            {                
                try
                {
                    Console.Write("Cedula: ");
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
                                    ingresarDeNuevo = false;
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
            ingresarDeNuevo = true;
            string telefono;
            char[] telefonoArray;
            while (ingresarDeNuevo)
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
                            ingresarDeNuevo = false;
                            vendedor.telefono = Convert.ToString(telefono);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Formato incorrecto, ingreselo nuevamente");
                }
            }
            ingresarDeNuevo = true;
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
                        ingresarDeNuevo = false;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, la fecha de nacimiento no puede ser menor a 18 años." + "\n");
                        Console.ResetColor();                       

                    }

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, la fecha o el formato no son correctos." + "\n");
                    Console.ResetColor();                    
                }
            } while (ingresarDeNuevo);

            ingresarDeNuevo = true;
            while (ingresarDeNuevo)
            {
                try
                {
                    Console.Write("Nombre de usuario : ");
                    var nombreusuario = Console.ReadLine();
                    int number;
                    if ((int.TryParse(nombreusuario, out number)) || (nombreusuario == ""))
                    {
                        throw new Exception();
                    }
                    var buscarUsusario = Lista_Personas.Find(x => ExisteNombreUsuario(x,nombreusuario));
                    if (buscarUsusario == null)
                    {
                        vendedor.usuario = nombreusuario;
                        ingresarDeNuevo = false;
                    }
                    else
                    {
                        Console.WriteLine("El usuario elegido ya existe, ingrese nuevamente");
                    }

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El nombre no puede ser vacio o un numero");
                    Console.ResetColor();
                }
                                
                ingresarDeNuevo = true;
                while (ingresarDeNuevo)
                {
                    try
                    {
                        Console.WriteLine("Ingrese Contraseña:");
                        var contrasenia = LeerContrasenia();
                        if (VerificarContrasenia(contrasenia))
                        {
                            Console.Write("Confirmar constraseña : ");
                            var confirmarContrasenia = LeerContrasenia();
                            if (contrasenia == confirmarContrasenia)
                            {
                                vendedor.contrasenia = contrasenia;
                                ingresarDeNuevo = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Las contraseñas no coinciden");
                                Console.ResetColor();
                                
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Formato incorrecto la contrasenia debe incluir al menos una mayuscula, una minuscula, un numero, un simbolo y un largo de al menos 8 caracteres");
                        Console.ResetColor();
                    }
                }


            }
            Lista_Personas.Add(vendedor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vendedor ingresado exitosamente" + "\n");
            Console.ResetColor();
        }

       
        public Persona BuscarCliente(string id)
        {
            return Lista_Personas.Find(x => x.cedula_Rut == Convert.ToInt32(id));
        }

        public bool ExistenClientes()
        {
            foreach (Persona persona in Lista_Personas)
            {
                if (persona.GetType() == typeof(Cliente))
                {
                    return true;
                }
            }

            return false;
        }

        public void CrearAdmin()
        {
            Vendedor admin = new Vendedor();
            admin.nombre = "Admin";
            admin.cedula_Rut = 53927851;
            admin.telefono = "12345678";
            //admin.fecha_Nacimiento = Convert.ToDateTime(12 / 12 / 98); me tira excepcion
            admin.usuario = "admin";
            admin.contrasenia = "Contra$en4";
            Lista_Personas.Add(admin);
        }
    }
}
