using System;
using System.Collections.Generic;
using System.Threading;


namespace Proyecto_C__UNAJ
{
    internal class Banco
    {
        //Atributos privados
        private string nombre;
        private List<Cliente> listaDeClientes;
        private List<Cuenta> listaDeCuentas;

        //Properties publicas
        public string Nombre { get; set; }
        public List <Cliente> ListaDeClientes { get; }
        public List <Cuenta> ListaDeCuentas { get; }
    
        //Contructors
        public Banco()   
        {
            ListaDeClientes = new List<Cliente>();    //inicializamos las listas vacias
            ListaDeCuentas = new List<Cuenta>();       //inicializamos las listas vacias
        }

        //Methods.
        //metodos clientes
        public void AgregarCliente(Cliente unCliente)  //opcion 1
            {
                ListaDeClientes.Add(unCliente); 
            }
        public void EliminarCliente(Cliente unCliente) //opcion 2
            { 
                ListaDeClientes.Remove(unCliente); 
            }
        public int CantidadClientes() // opcion 3
            {
                return ListaDeClientes.Count;
            }
        public bool ExisteCliente(Cliente unCliente) //opcion 4
            { 
                return ListaDeClientes.Contains(unCliente); 
            }
        public Cliente VerCliente(int i) // opcion 5
            { 
                return ListaDeClientes[i]; 
            }
        public List<Cliente> TodosClientes() // opcion 6
            { 
                return ListaDeClientes; 
            }

        //metodos cuenta
        public void AgregarCuenta(Cuenta unaC)  //7
        { ListaDeCuentas.Add(unaC); }
        public void EliminarCuenta(Cuenta unaC) //8
        { ListaDeCuentas.Remove(unaC); }
        public int CantidadCuentas() //9
        { return ListaDeCuentas.Count; }
        public bool ExisteCuenta(Cuenta unaC) //10
        { return ListaDeCuentas.Contains(unaC); }
        public Cuenta VerCuenta(int i) //11
        { return ListaDeCuentas[i]; }
        public List<Cuenta> TodasCuentas() //12
        { return ListaDeCuentas; }





    }
}
