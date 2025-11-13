using System;
using System.Collections.Generic;


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
	    public int Dni{
	        get{return dni;}
	        set{dni = value;}
        }
	    public string Direccion{
		    get{return direccion;}
		    set{direccion = value;}
        }
        public string Email{
	        get{return email;}
	        set{email = value;}
        }    
        public int Telefono{
	        get{return telefono;}
	        set{telefono = value;}
        }
 
        //constructores
        public Cliente(string nom, string ape, int dni, string dire, int tel, string mail)
        {
            this.Nombre = nom;
            this.Apellido = ape;    
            this.Dni = dni;
            this.Direccion = dire;
            this.Telefono = tel;
            this.Email = email;
        }
    
		//methods
        public override string ToString()
        {
           
            return string.Format ("Nombre: {0}, Apellido: {1}, DNI: {2}",this.Nombre, this.Apellido,this.Dni);
        }

    }
}
