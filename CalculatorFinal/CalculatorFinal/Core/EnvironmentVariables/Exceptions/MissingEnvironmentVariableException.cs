using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Core.EnvironmentVariables.Exceptions
{
    public class MissingEnvironmentVariableException : Exception
    {
        public MissingEnvironmentVariableException()
        { }

        public MissingEnvironmentVariableException(string message) : base(message)
        { }

        public MissingEnvironmentVariableException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
