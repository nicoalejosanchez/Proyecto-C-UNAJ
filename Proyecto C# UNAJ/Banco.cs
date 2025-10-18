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
        public void AgregarCliente(Cliente unCliente)  
            {
                ListaDeClientes.Add(unCliente); 
            }
        public void EliminarCliente(Cliente unCliente) 
            { 
                ListaDeClientes.Remove(unCliente); 
            }
        public int CantidadClientes() 
            {
                return ListaDeClientes.Count;
            }
        public bool ExisteCliente(Cliente unCliente)
            { 
                return ListaDeClientes.Contains(unCliente); 
            }
        public Cliente VerCliente(int i) 
            { 
                return ListaDeClientes[i]; 
            }
        public List<Cliente> TodosLosClientes() 
            { 
                return ListaDeClientes; 
            }

        //metodos cuenta
        public void AgregarCuenta(Cuenta unaC)  
        { ListaDeCuentas.Add(unaC); }
        public void EliminarCuenta(Cuenta unaC) 
        { ListaDeCuentas.Remove(unaC); }
        public int CantidadCuentas() 
        { return ListaDeCuentas.Count; }
        public bool ExisteCuenta(Cuenta unaC) 
        { return ListaDeCuentas.Contains(unaC); }
        public Cuenta VerCuenta(int i) 
        { return ListaDeCuentas[i]; }
        public List<Cuenta> TodasCuentas() 
        { return ListaDeCuentas; }





    }
}
