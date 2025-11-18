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
       

        public string Nombre {
		    get { return nombre; }
		    set { nombre = value; }
        }

        public string Apellido {
	        get { return apellido; }
	        set { apellido = value; }
        }
	    
		public int Dni {
	        get { return dni; }
	        set { dni = value; }
        }
		
	    public string Direccion {
		    get { return direccion; }
		    set { direccion = value; }
		}   
		
        public int Telefono {
	        get { return telefono; }
	        set { telefono = value; }
        }	
			
        public string Email {
	        get { return email; }
	        set { email = value; }
		}
        
        //constructores
        public Cliente(string nom, string ape, int dni, string dire, int tel, string email)
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
           
            return string.Format ("Nombre: {0}, Apellido: {1}, DNI: {2}",this.Nombre, this.Apellido,this.Dni);
        }

    }
}
