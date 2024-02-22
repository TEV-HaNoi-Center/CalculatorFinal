using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Views.Calculator.Exceptions
{
    public class NotAllowedElementInQueueException : Exception
    {
        public NotAllowedElementInQueueException()
        { }

        public NotAllowedElementInQueueException(string message) : base(message)
        { }

        public NotAllowedElementInQueueException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
