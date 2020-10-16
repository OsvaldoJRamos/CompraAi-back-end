using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CompraAi.Dominio.Validacoes
{
    public class ValidacaoEntidadeException : ArgumentException
    {
        public ValidacaoEntidadeException()
        {
        }

        public ValidacaoEntidadeException(string message) : base(message)
        {
        }

        public ValidacaoEntidadeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValidacaoEntidadeException(string message, string paramName) : base(message, paramName)
        {
        }

        public ValidacaoEntidadeException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }

        protected ValidacaoEntidadeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
