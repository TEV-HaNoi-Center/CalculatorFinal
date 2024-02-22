using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Views.Calculator.Exceptions
{
    public class NotAllowedOperatorInMethodException : Exception
    {
        public NotAllowedOperatorInMethodException()
        { }

        public NotAllowedOperatorInMethodException(string message) : base(message)
        { }

        public NotAllowedOperatorInMethodException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
