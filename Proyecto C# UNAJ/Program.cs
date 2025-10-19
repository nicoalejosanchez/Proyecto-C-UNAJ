using System;
using System.Collections.Generic;
using System.Threading;

namespace Proyecto_C__UNAJ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();
            ImprimirMenu();

            int opcionParaElCase;

            if (int.TryParse(Console.ReadLine(), out opcionParaElCase)) 
            {
                while (opcionParaElCase != 0)
                {


                    switch (opcionParaElCase)
                    {
                        case 0:
                            {
                                Console.WriteLine("Fin del programa");
                                break;
                            }

                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("___AGREGAR CUENTA___");
                                Console.WriteLine("Ingrese el DNI del titular de la cuenta: ");
                                int dni = Int32.Parse(Console.ReadLine());
                                bool existe = false;

                                // me fijo si el cliente ya tiene otra cuenta
                                foreach (var cuenta in banco.ListaDeCuentas)    //no podemos usar el metodo de banco "ExisteCliente" porque necesitamos el obj completo??
                                {
                                    if (cuenta.DniDelTitularDeLaCuenta == dni)
                                    {
                                        existe = true;
                                        break;
                                    }

                                }

                                //si tiene >

                                if (existe)
                                {
                                    Console.WriteLine("Ingrese el apellido del titular de la cuenta: ");
                                    string apellido = Console.ReadLine();

                                    double saldo = 0;

                                    Console.Write("Creando cuenta......");

                                    //creo la cuenta 
                                    Cuenta cuenta = new Cuenta(apellido, dni, saldo);


                                    banco.AgregarCuenta(cuenta); /////////////metodo agregar cuenta
                                    Thread.Sleep(1000); //simula espera 1 seg
                                    Console.WriteLine("\nCuenta creanda con exito.");
                                }
                                // si no tiene cuenta tengo que dar de alta el cliente--->>
                                else
                                {
                                    Console.WriteLine("---CLIENTE NUEVO---\nCompletar datos para dal de alta nuevo cliente: ");
                                    Console.Write("Ingrese nombre: ");
                                    string nombre = Console.ReadLine();
                                    Console.Write("Ingrese apellido: ");
                                    string apellido = Console.ReadLine();
                                    Console.Write("Direccion: ");
                                    string direcc = Console.ReadLine();
                                    Console.Write("Telefono: ");
                                    int tel = int.Parse(Console.ReadLine());
                                    Console.Write("E-Mail: ");
                                    string mail = Console.ReadLine();

                                    Console.WriteLine("Agregando cliente nuevo... ");

                                    Cliente clienteNuevo = new Cliente(nombre, apellido, dni, direcc, tel, mail);
                                    banco.AgregarCliente(clienteNuevo); /////////////////////metodo agregar cliente
                                    Thread.Sleep(500);
                                    Console.WriteLine("Flag se creo cliente nuevo");
                                    Console.WriteLine("Creando cuenta......");

                                    int saldo = 0;              //inicio la cuenta con saldo 0
                                    Cuenta cuenta = new Cuenta(apellido, dni, saldo);
                                    Console.WriteLine(cuenta.ToString()); //flag para ver la cuenta
                                    banco.AgregarCuenta(cuenta);
                                    Console.WriteLine("\nCUENTA CREADA CON EXITO.");

                                  
                                    Console.WriteLine("");
                                    Console.WriteLine("Cuanto $ deposita: ");
                                    double cuanto = double.Parse(Console.ReadLine());
                                    cuenta.DepositarSaldo(cuanto);

                                }
                                Thread.Sleep(1000);
                                ImprimirMenu();
                                int.TryParse(Console.ReadLine(), out opcionParaElCase);
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine(  "---ELIMINAR CUENTA---");
                                Console.WriteLine("CBU de la cuenta que quiere eliminar: ");
                                int cbuingresado = int.Parse(Console.ReadLine());

                                Cuenta cuentaParaEliminar = null;

                                foreach (var cuenta in banco.())
                                {
                                    if (cuenta.Cbu == cbuingresado)
                                    {
                                        cuentaParaEliminar = cuenta;
                                        banco.EliminarCuenta(cuentaParaEliminar);
                                        Console.WriteLine("Cuenta eliminada");
                                        break;
                                    }
                                }
                                if (cuentaParaEliminar == null)
                                {
                                    Console.WriteLine("No se elimnino nada, crear si o si un exption aca"); //crear exeption aca
                                }

                                //busco al cliente en la lista de cuentas 

                                Cliente clienteBuscado = null;
                                foreach (var cliente in banco.TodosLosClientes())
                                {
                                    if (cliente.Dni == cuentaParaEliminar.DniDelTitularDeLaCuenta)
                                    {
                                        clienteBuscado = cliente;
                                        break; 
                                    }
                                } // ahora tengo al cliente al que le eliminamos la cuenta en la variable clienteBuscado

                              
                                //busco si tiene otra cuenta
                                bool tieneOtraCuenta = false;
                                foreach (var cuenta in banco.TodasCuentas())
                                {
                                    if (cuenta.DniDelTitularDeLaCuenta == clienteBuscado.Dni)
                                    {
                                        tieneOtraCuenta = true;
                                        break;
                                    }
                                }
                                // Si no tiene otra cuenta, eliminar el cliente tambien
                                if (!tieneOtraCuenta) //si es falso que tiene otra cuenta eliminamos al cliente
                                {
                                    banco.EliminarCliente(clienteBuscado);
                                    Console.WriteLine("El cliente también fue eliminado porq no tener + cuentas.");
                                }
                                Thread.Sleep(1000);
                                ImprimirMenu();
                                int.TryParse(Console.ReadLine(), out opcionParaElCase);
                                break;
                            }
                        case 3:
                            {
                                //Listado de clientes que tienen más de una cuenta , indicando nro
                                //de cuenta y saldo de cada una.

                                foreach (var cliente in banco.TodosLosClientes())
                                {
                                    List<Cuenta> listaFlagMultiplesCuentas = new List<Cuenta>();
                                    foreach (var cuenta in banco.TodasCuentas())
                                    {
                                        if (cuenta.DniDelTitularDeLaCuenta == cliente.Dni)
                                        {
                                            listaFlagMultiplesCuentas.Add(cuenta);

                                        }
                                    }
                                    if (listaFlagMultiplesCuentas.Count >1)
                                    {
                                        Console.WriteLine(cliente.ToString());

                                        foreach (var cuenta in listaFlagMultiplesCuentas)
                                        {
                                            Console.WriteLine($"CBU: {cuenta.Cbu}, Saldo: {cuenta.SaldoDeLaCuenta}");
                                        }
                                    }
                                    Console.WriteLine("");
                                }
                                Thread.Sleep(1000);
                                ImprimirMenu();
                                int.TryParse(Console.ReadLine(), out opcionParaElCase);
                                break;
                            }
                        case 4:
                            {
                                //Realizar una extracción. En caso de no poseer saldo suficiente se
                                //debe levantar una excepción que indique lo sucedido(“Saldo insuficiente”)
                                Console.Clear();
                                Console.WriteLine("REALIZAR UNA EXTRACCION DE $ ");
                                Console.WriteLine("CBU de la cuenta que quiere extraer dinero: ");
                                int cbu = int.Parse(Console.ReadLine());
                                Cuenta flagCuenta = null;
                                foreach(var cuenta in banco.TodasCuentas())
                                {
                                    if ( cuenta.Cbu == cbu)
                                    {
                                        flagCuenta = cuenta;
                                    }
                                }
                                if (flagCuenta == null)
                                {
                                    Console.WriteLine("CBU no encontrado"); // hay que crar una exeption aca
                                }

                                Console.WriteLine("Cuanto $ quiere extrae?: ");
                                double cuanto = double.Parse(Console.ReadLine());

                                if (flagCuenta.SaldoDeLaCuenta >= cuanto)
                                {
                                    flagCuenta.ExtraerSaldo(cuanto);
                                    
                                    Console.WriteLine("flag se retiro correctamente");
                                    Console.WriteLine();
                                    Console.WriteLine($"El nuevo saldo de la cuenta: {flagCuenta.ToString()} es: {flagCuenta.SaldoDeLaCuenta}");
                                }
                                else
                                {
                                    Console.WriteLine(  "saldo insuficiente"); // tambien hay que crear la exepcion, esta improvisado
                                }




                                ImprimirMenu();
                                int.TryParse(Console.ReadLine(), out opcionParaElCase);
                                break;

                            }
                        case 5:
                            {
                                //Depositar dinero en una cuenta dada.
                                Console.Clear();
                                Console.WriteLine("DEPOSITAR DINERO");
                                Console.WriteLine("CBU de la cuenta a la que quiere depositar: ");
                                int cbu = int.Parse(Console.ReadLine());

                                Cuenta cuentaDeDeposito = null;
                                foreach(var cuenta in banco.TodasCuentas())
                                {
                                    if (cuenta.Cbu == cbu)
                                    {
                                        cuentaDeDeposito = cuenta;
                                    }
                                }

                                Console.WriteLine("Cuanto $ deposita: ");
                                double cuantoDeposita = double.Parse(Console.ReadLine());

                                cuentaDeDeposito.DepositarSaldo(cuantoDeposita); //?????????????????????????????????????????? no entendi lo de cuenta dada, si es un obj cuenta o el cbu o q

                                Thread.Sleep(500);
                                ImprimirMenu();
                                int.TryParse(Console.ReadLine(), out opcionParaElCase);
                                break;
                                
                            }

                        case 6:
                            {
                                //Transferir dinero entre dos cuentas. Validar existencia de saldo
                                //en la cuenta origen.asdasd

                                Console.Clear();
                                Console.WriteLine("***  TRANFERENCIA  ****");
                                Console.WriteLine();
                                Console.WriteLine("CBU de la cuenta de origen: ");
                                int cbuOrigen = int.Parse(Console.ReadLine());

                                Cuenta cuentaFlag = null;
                                foreach (var cuenta in banco.TodasCuentas())
                                {
                                    if (cuenta.Cbu == cbuOrigen)
                                    {
                                        cuentaFlag = cuenta;
                                    }
                                }

                                Console.WriteLine("El saldo de la cuenta de origen es: "+cuentaFlag.SaldoDeLaCuenta);

                                //falta terminar<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<



                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("LISTADO DE CUENTAS");
                                foreach (var cuenta in banco.TodasCuentas())
                                {
                                   
                                    Console.WriteLine( cuenta.ToString() );
                                    Console.WriteLine();
                                }
                                Thread.Sleep(1000);
                                ImprimirMenu();
                                int.TryParse(Console.ReadLine(), out opcionParaElCase);
                                break;
                            }
                        case 8:
                            {
                                int flagNumeroIncremen = 0;
                                Console.Clear();
                                Console.WriteLine("LISTADO DE CLIENTES");
                                foreach (var cliente in banco.TodosLosClientes())
                                {
                                    Console.Write(flagNumeroIncremen+1 + " - ");
                                    Console.WriteLine(cliente.ToString());
                                    Console.WriteLine("");
                                }


                                Thread.Sleep(1000);
                                ImprimirMenu();
                                int.TryParse(Console.ReadLine(), out opcionParaElCase);
                                break; 
                            }
                    }
                }
            }



        }
        public static void ImprimirMenu()
        {
            Console.WriteLine("===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Agregar cuenta al banco");
            Console.WriteLine("2. Eliminar cuenta");
            Console.WriteLine("3. Listar clientes con mas de una cuenta");
            Console.WriteLine("4. Extraer $ ");
            Console.WriteLine("5. Depositar $ ");
            Console.WriteLine("6. ");

            Console.WriteLine("7.listado de cuentas ");
            Console.WriteLine("8. listado de clientes  ");
            ;
            
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

        }

        



    }
}
