using CalculatorFinal.Core.Enums;
using CalculatorFinal.Core.EnvironmentVariables;
using CalculatorFinal.Core.EnvironmentVariables.Enums;
using CalculatorFinal.Core.EnvironmentVariables.Exceptions;
using CalculatorFinal.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Core.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentType GetEnvironmentType()
        {
            int environmentTypeCode;

            string environmentVariableKey =
                EnvironmentVariableKeys.GetEnvironmentVariableKey(EnvironmentVariableKey.EnvironmentType);

            if (int.TryParse(Environment.GetEnvironmentVariable(environmentVariableKey), out environmentTypeCode))
            {
                return (EnvironmentType)environmentTypeCode;
            }

            if (int.TryParse(ConfigurationManager.AppSettings[environmentVariableKey], out environmentTypeCode))
            {
                return (EnvironmentType)environmentTypeCode;
            }

            throw new MissingEnvironmentVariableException($"Missing OS Environment Variable name: {environmentVariableKey}");
        }
    }
}
