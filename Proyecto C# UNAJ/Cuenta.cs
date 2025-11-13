using System;
using System.Collections.Generic;

namespace Proyecto_C__UNAJ
{
    internal class Cuenta
    {
        private static int numerosDeCbu = 10000; // para que los cbu sean unicos, es un atributo de la clase

        //atributos
        private string cbu;
        private string apellidoDelTitularDeLaCuenta;
        private int dniDelTitularDeLaCuenta;
        private double saldoDeLaCuenta;
       
        //properties
        /*public int Cbu { get; set; }
        public string ApellidoDelTitularDeLaCuenta { get; set; }
        public int DniDelTitularDeLaCuenta { get; set; }
        public double SaldoDeLaCuenta { get; set; }
        */
        public string Cbu{
		    get{return cbu;}
		    set{cbu = value;}
        }
 	
	    public string ApellidoDelTitularDeLaCuenta{
		    get{return apellidoDelTitularDeLaCuenta;}
		    set{apellidoDelTitularDeLaCuenta= value;}
        }

        public int DniDelTitularDeLaCuenta{
	        get{return dniDelTitularDeLaCuenta;}
	        set{dniDelTitularDeLaCuenta = value;}
        }

        public double SaldoDeLaCuenta{
	        get{return saldoDeLaCuenta;}
	        set{saldoDeLaCuenta = value;}
        }

        //constructor
        public Cuenta(string apellidoDelTitular, int dniDelTitular, double saldoDeLaCuenta)
        {
            //this.Cbu = CrearCbu();
            this.ApellidoDelTitularDeLaCuenta = apellidoDelTitular;
            this.DniDelTitularDeLaCuenta = dniDelTitular;
            this.SaldoDeLaCuenta = saldoDeLaCuenta;
            numerosDeCbu++;
            this.cbu = numerosDeCbu.ToString();
        }
        
		//Methods
        public void TranferirSaldo()
        {

        }
        public void ExtraerSaldo( double cuantoSaca)
        {
            this.SaldoDeLaCuenta -= cuantoSaca;
        }
        public void DepositarSaldo( double cuantoDeposita)
        {
            SaldoDeLaCuenta += cuantoDeposita;
        }

        public override string ToString()
        {
            return ("CBU: " + this.Cbu +
                "\nApellido del titular: " + this.ApellidoDelTitularDeLaCuenta+
                "\nDNI del titular: " + this.DniDelTitularDeLaCuenta+
                "\nSaldo de la cuenta: " + this.SaldoDeLaCuenta);
        }
    }
}

