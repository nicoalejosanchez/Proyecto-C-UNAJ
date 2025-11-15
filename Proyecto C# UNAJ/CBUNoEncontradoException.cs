using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_C__UNAJ
{
    internal class CBUNoEncontradoException : Exception
    {
        //uno da mensaje por defec y el otro el mj que quieras poner en el catch
        public CBUNoEncontradoException() : base("CBU no encontrado") { }
        
        public CBUNoEncontradoException(string mensaje) : base(mensaje) { }
    }
    internal class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() : base("Saldo insuficiente") { }
    }
    
    internal class DNIInvalidoEception: Exception
    {
        public DNIInvalidoEception() : base("DniInvalido") { }
    }
    internal class DepositoInvalidoException: Exception
    {
        public DepositoInvalidoException() : base("DepositoInvalido"){ }
    }


}
