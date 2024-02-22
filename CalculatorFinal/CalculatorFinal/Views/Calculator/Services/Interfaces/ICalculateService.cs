using CalculatorFinal.Views.Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Views.Calculator.Services.Interfaces
{
    public interface ICalculateService
    {
        double Calculate(Queue<string> queue, AngleUnitType angleUnitType);
    }
}
