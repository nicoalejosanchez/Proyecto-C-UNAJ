using System;
using System.Collections.Generic;


namespace Proyecto_C__UNAJ
{
    internal class Cliente
    {
        //atributos
        private string nombre;
        private string apellido;
        private string dni;
        private string direccion;
        private int telefono;
        private string email;
       
        //properties
       /* public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public int Dni { get; set; }  
        public string Direccion { get; set;}
        public int Telefono { get; set;}
        public string Email { get; set;}  */

        public string Nombre{
		    get{return nombre;}
		    set{nombre = value;}
        }
        public string Apellido{
	        get{return apellido;}
	        set{apellido = value;}
        }
	    public string Dni{
	        get{dni nombre;}
	        set{dni = value;}
        }
	    public string Direccion{
		    get{return direcion;}
		    set{direccion = value;}
        }
        public string Mail{
	        get{return mail;}
	        set{mail = value;}
        }    
        public int Numero{
	        get{return numero;}
	        set{numero = value;}
        }


        
        
        //constructores
        public Cliente(string nom, string ape, string dni, string dire, int tel, string mail)
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
