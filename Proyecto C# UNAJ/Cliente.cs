using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_C__UNAJ
{
    internal class Cliente
    {
        //atributos
        private string nombre;
        private string apellido;
        private int dni;
        private string direccion;
        private int telefono;
        private string email;
        //properties
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public int Dni { get; set; }  
        public string Direccion { get; set;}
        public int Telefono { get; set;}
        public string Email { get; set;}    
        
        //constructores
        public Cliente(string nom, string ape, int dni, string dire, int tel, string mail)
        {
            this.Nombre = nom;
            this.Apellido = ape;    
            this.Dni = dni;
            this.Direccion = dire;
            this.Telefono = tel;
            this.Email = mail;
        }


        //methods

        public override string ToString()
        {
           
            return ($"Nombre: {this.Nombre}, Apellido: {this.Apellido}, DNI: {this.Dni} ");
        }

    }
}
