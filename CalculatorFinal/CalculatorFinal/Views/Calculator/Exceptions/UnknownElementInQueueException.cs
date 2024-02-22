using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Views.Calculator.Exceptions
{
    public class UnknownElementInQueueException : Exception
    {
        public UnknownElementInQueueException()
        { }

        public UnknownElementInQueueException(string message) : base(message)
        { }

        public UnknownElementInQueueException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
