using System;
using System.Collections.Generic;

namespace Proyecto_C__UNAJ
{
    internal class Cuenta
    {
        private static int numerosDeCbu; // para que los cbu sean unicos, es un atributo de la clase

        //atributos
        private int cbu;
        private string apellidoDelTitularDeLaCuenta;
        private int dniDelTitularDeLaCuenta;
        private double saldoDeLaCuenta;
        //properties
        public int Cbu { get; set; }
        public string ApellidoDelTitularDeLaCuenta { get; set; }
        public int DniDelTitularDeLaCuenta { get; set; }
        public double SaldoDeLaCuenta { get; set; }
        //constructor
        public Cuenta() 
        { 

        }
        public Cuenta(string apellidoDelTitular, int dniDelTitular, double saldoDeLaCuenta)
        {
            this.Cbu = CrearCbu();
            this.ApellidoDelTitularDeLaCuenta = apellidoDelTitular;
            this.DniDelTitularDeLaCuenta = dniDelTitular;
            this.SaldoDeLaCuenta = saldoDeLaCuenta;
        }
        //Methods
        public void TranferirSaldo()
        {

        }
        public void DepositarSaldo( double cuantoDeposita)
        {
            SaldoDeLaCuenta += cuantoDeposita;
        }


        public int CrearCbu() 
        {
            return ++numerosDeCbu;
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
