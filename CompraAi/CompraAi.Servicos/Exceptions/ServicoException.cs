using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CompraAi.Servicos.Exceptions
{
    public class ServicoException : Exception
    {
        public ServicoException()
        {
        }

        public ServicoException(string message) : base(message)
        {
        }

        public ServicoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServicoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
