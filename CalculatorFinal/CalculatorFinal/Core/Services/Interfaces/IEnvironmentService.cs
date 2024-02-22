using CalculatorFinal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Core.Services.Interfaces
{
    public interface IEnvironmentService
    {
        EnvironmentType GetEnvironmentType();
    }
}
