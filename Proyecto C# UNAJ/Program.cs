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
            int maximo =  8;
            int minimo = 0;

            if (int.TryParse(Console.ReadLine(), out opcionParaElCase) || opcionParaElCase > minimo || opcionParaElCase < maximo ) 
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

                                int dni;

                                while (!int.TryParse(Console.ReadLine(), out dni))
                                {
                                    Console.WriteLine("Error>>> ingrese un DNI (solo números): ");
                                }


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
                                    Console.WriteLine("  ");
                                    
                                    string nombre;
                                 
                                    string apellido;
                                    string direcc;
                                    try{
                                    	Console.Write("Nombre: ");
                                    	nombre = Console.ReadLine();
                                    	
                                    	ValidarLetra(nombre);
                                    	
                                    	Console.Write("Apellido: ");
                                    	apellido = Console.ReadLine();
                                    	
                                    	ValidarLetra(apellido);
                                    	
                                    	Console.Write("Direccion: ");
                                    	direcc = Console.ReadLine();
                                    	
                                    	ValidarLetra(direcc);
                                    
                              
                                    Console.Write("Telefono: ");

                                    int tel;
                                    while(!int.TryParse(Console.ReadLine(), out tel))
                                    {
                                        Console.WriteLine("ingrese un telefo valido: ");
                                    }
                                    

                                    Console.Write("E-Mail: ");
                                    string mail = Console.ReadLine();

                                    Console.WriteLine("Agregando cliente nuevo... ");

                                    Cliente clienteNuevo = new Cliente(nombre, apellido, dni, direcc, tel, mail);
                                    banco.AgregarCliente(clienteNuevo); /////////////////////metodo agregar cliente
                                    Thread.Sleep(500);
                                    Console.WriteLine("  ");
                                    Console.WriteLine("Creando cuenta......");
                                    Console.WriteLine("  ");
                                    int saldo = 0;              //inicio la cuenta con saldo 0
                                    Cuenta cuenta = new Cuenta(apellido, dni, saldo);
                                    Console.WriteLine(cuenta.ToString()); //flag para ver la cuenta
                                    banco.AgregarCuenta(cuenta);
                                    Console.WriteLine("\nCUENTA CREADA CON EXITO.");
                                    
                                     Console.WriteLine("");
                                    Console.WriteLine("Cuanto $ deposita: ");

                                    double cuanto; 
                                    while (!double.TryParse(Console.ReadLine(),out cuanto))
                                            {
                                                  Console.WriteLine("Error. Ingrese un número válido:");
                                           }
                                        
                                    cuenta.DepositarSaldo(cuanto);

                                    
                                    Console.WriteLine("Nuevo saldo en cuenta: {0}", cuenta.SaldoDeLaCuenta);
                                    }
                                    catch (CaracterInvalidoException ex)
    									{
       										 // Aquí cae si ValidarLetra encuentra un número o símbolo
    										 Console.WriteLine("ERROR: " + ex.Message);
       										 Console.WriteLine("Volviendo al menú principal...");
    									}
    								catch (Exception ex)
    									{
     										  Console.WriteLine("Error inesperado: " + ex.Message);
   										}
                                    
                                  
                                   

                                }
                               break;
                             }
                    		
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine(  "---ELIMINAR CUENTA---");
                                Console.WriteLine(  "Muestro las cuentas. ");
                                foreach (var cuenta in banco.TodasCuentas())
                                {

                                    Console.WriteLine(cuenta.ToString());
                                    Console.WriteLine();
                                }
                                Console.WriteLine("CBU de la cuenta que quiere eliminar: ");

                                int cbuingresado;
                                while (!int.TryParse(Console.ReadLine(), out cbuingresado))
                                    {
                                    Console.WriteLine("Error: ingrese un cbu válido (solo números): ");
                                }

                                Cuenta cuentaParaEliminar = null;

                                try
                                {
                                    foreach (var cuenta in banco.TodasCuentas())
                                    {
                                        if (cuenta.Cbu == cbuingresado.ToString())
                                        {
                                            cuentaParaEliminar = cuenta;
                                            break; //para qu no siga busacndo
                                        }
                                    }
                                    if (cuentaParaEliminar == null)
                                    {
                                        throw new CBUNoEncontradoException();
                                    }

                                    banco.EliminarCuenta(cuentaParaEliminar);
                                    Console.WriteLine("Cuenta eliminada");


                                }
                                catch (CBUNoEncontradoException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    break;
                                }

                                


                                //busco al cliente en la lista de cuentas 

                                Cliente clienteBuscado = null;
                                foreach (var cliente in banco.TodosLosClientes())
                                {
                                    if (cliente.Dni == cuentaParaEliminar.DniDelTitularDeLaCuenta)  ///esta cuentaParaEliminar me quedo afuera del contecto acutal como la sumo
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
                              
                                break;
                            }
                        case 3:
                            {
                                //Listado de clientes que tienen más de una cuenta , indicando nro
                                //de cuenta y saldo de cada una.
                                Console.Clear();
                                Console.WriteLine("CLIENTES CON AMS DE UNA CUENTA");
                                bool hayClientesConMultiples = false;
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
                                        hayClientesConMultiples = true;
                                        Console.WriteLine(cliente.ToString());

                                        foreach (var cuenta in listaFlagMultiplesCuentas)
                                        {
                                            Console.WriteLine("CBU: {0}, Saldo: {1}", cuenta.Cbu,cuenta.SaldoDeLaCuenta );
                                        }
                                        Console.WriteLine("");
                                    }
                                    if (!hayClientesConMultiples)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Todavia no hay clientes con mas de una cuenta");
                                    }
                                    Console.WriteLine("");
                                }
                        
                                break;
                            }
                        case 4:
                            {
                                //Realizar una extracción. En caso de no poseer saldo suficiente se
                                //debe levantar una excepción que indique lo sucedido(“Saldo insuficiente”)
                                Console.Clear();
                                Console.WriteLine("REALIZAR UNA EXTRACCION DE $ ");
                                Console.WriteLine("CBU de la cuenta que quiere extraer dinero: ");
                                

                                Cuenta flagCuenta = null;

                                try {
                                    int cbu = int.Parse(Console.ReadLine());

                                    //busca la cuenta con ese cbu
                                    foreach (var cuenta in banco.TodasCuentas())
                                    {
                                        if (cuenta.Cbu == cbu.ToString())
                                        {
                                            flagCuenta = cuenta;
                                            break; //para que no siga buscando
                                        }
                                    }

                                    //si no exite la cuenta tira la exception

                                    if (flagCuenta == null)
                                    {
                                        throw new CBUNoEncontradoException("El CBU ingresado no existe");
                                    }
                                }
                                catch (CBUNoEncontradoException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    break; // SALE DEL CASE, no seguir ejecutando
                                }
                                catch
                                {
                                    Console.WriteLine("Error: CBU inválido."); //si puso letras o algo
                                    break;
                                }

                                //aca es si existe el cbu

                                Console.WriteLine("Cuanto $ quiere extrae?: ");
                                double cuanto;
                                 while (!double.TryParse(Console.ReadLine(),out cuanto))
                                            {
                                                  Console.WriteLine("Error. Ingrese un valor válido:");
                                           }

                                //valido saldo
                                try
                                {
                                    if (flagCuenta.SaldoDeLaCuenta < cuanto)
                                    {
                                        throw new SaldoInsuficienteException();
                                    }
                                    flagCuenta.ExtraerSaldo(cuanto);

                                    Console.WriteLine("monto se retiro correctamente");
                                    Console.WriteLine();
                                    Console.WriteLine("El nuevo saldo de la cuenta es: {0}", flagCuenta.SaldoDeLaCuenta);
                                }

                                catch (SaldoInsuficienteException ex)
                                {
                                    Console.WriteLine(  ex.Message);
                                }

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
                                	if (cuenta.Cbu == cbu.ToString())
                                    {
                                        cuentaDeDeposito = cuenta;
                                    }
                                }

                                Console.WriteLine("Cuanto $ deposita: ");
                                double cuantoDeposita;
                        
                                while (!double.TryParse(Console.ReadLine(),out cuantoDeposita))
                                            {
                                                  Console.WriteLine("Error. Ingrese un valor válido:");
                                           }

                                cuentaDeDeposito.DepositarSaldo(cuantoDeposita); //?????????????????????????????????????????? no entendi lo de cuenta dada, si es un obj cuenta o el cbu o q
                                Console.WriteLine("Nuevo saldo en cuenta: {0}", cuentaDeDeposito.SaldoDeLaCuenta);
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
                                Console.Write("CBU de la cuenta de destino: ");
                                int cbuDestino = int.Parse(Console.ReadLine());
                                Console.Write("Monto a transferir: ");
                                double monto;
                                while (!double.TryParse(Console.ReadLine(), out monto))
                                {
                                    Console.WriteLine("Error>>> ingrese monto valido (solo números): ");
                                }
                                
                                // Buscar cuentas en la lista del banco
                                Cuenta cuentaOrigen = null;
                                Cuenta cuentaDestino = null;
                                
                                foreach (var cuenta in banco.TodasCuentas())
                                {
                                	if (cuenta.Cbu == cbuOrigen.ToString())
                                        cuentaOrigen = cuenta;
                                	else if (cuenta.Cbu == cbuDestino.ToString())
                                        cuentaDestino = cuenta;
                                }

                                if (cuentaOrigen == null || cuentaDestino == null)
                                {
                                    Console.WriteLine("Error: una o ambas cuentas no existen.");
                                }
                                else
                                {
                                    // Validar saldo en cuenta de origen
                                    if (cuentaOrigen.SaldoDeLaCuenta >= monto)
                                    {
                                        cuentaOrigen.ExtraerSaldo(monto);
                                        cuentaDestino.DepositarSaldo(monto);
                                        
                                        Console.WriteLine("\nTransferencia realizada correctamente.");
                                        Console.WriteLine("Nuevo saldo cuenta origen: {0}",cuentaOrigen.SaldoDeLaCuenta);
                                        Console.WriteLine("Nuevo saldo cuenta destino: {0}",cuentaDestino.SaldoDeLaCuenta);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nError: saldo insuficiente en la cuenta de origen.");
                                    }
                                }

                                break;
                            }
                        case 7:
                            {
                                Console.Clear();
                                Console.WriteLine("LISTADO DE CUENTAS");
                                Console.WriteLine("");
                                foreach (var cuenta in banco.TodasCuentas())
                                {
                                   
                                    Console.WriteLine( cuenta.ToString() );
                                    Console.WriteLine();
                                }
                                Thread.Sleep(1000);
                  
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


                                break; 
                            }
                    }
                     
                     Console.WriteLine();
        			 ImprimirMenu();
        			 int.TryParse(Console.ReadLine(), out opcionParaElCase);
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
            Console.WriteLine("6. Transferir dinero entre cuentas");

            Console.WriteLine("7.listado de cuentas ");
            Console.WriteLine("8. listado de clientes  ");
            ;
            
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

        }

        public static void ValidarLetra(string b)
		{
   			 // Valida si es nulo o vacío
   			 if (b == null || b == "")
    		{
        		throw new CaracterInvalidoException();
   			 }

    		
    		foreach (char c in b)
    		{
        		
        		if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' '))
        		{
            		throw new CaracterInvalidoException();
        		}
    		}
		}

    }
}
