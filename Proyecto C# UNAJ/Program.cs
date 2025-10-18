using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                                Console.WriteLine("CBU de la cuenta que quiere eliminar: ");
                                int cbuingresado = int.Parse(Console.ReadLine());

                                Cuenta cuentaParaEliminar = null;

                                foreach (var cuenta in banco.ListaDeCuentas)
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
                                foreach (var cliente in banco.ListaDeClientes)
                                {
                                    if (cliente.Dni == cuentaParaEliminar.DniDelTitularDeLaCuenta)
                                    {
                                        clienteBuscado = cliente;
                                        break; 
                                    }
                                } // ahora tengo al cliente al que le eliminamos la cuenta en la variable clienteBuscado

                              
                                //busco si tiene otra cuenta
                                bool tieneOtraCuenta = false;
                                foreach (var cuenta in banco.ListaDeCuentas)
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

                                break;
                            }
                        case 3:
                            {
                                List <Cliente> listaCompleta = banco.TodosClientes();

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
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");

            Console.WriteLine("7. ");
            Console.WriteLine("8.  ");
            Console.WriteLine("9. ");
            
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

        }

        



    }
}
