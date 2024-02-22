using CalculatorFinal.Core.CommandParameters.Interfaces;
using CalculatorFinal.Views.Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Views.Calculator.CommandParameters
{
    public class OperandCommandParameter : ICommandParameter
    {
        public UserInteractionType UserInteractionType { get; }

        public int OperandValue { get; }

        public OperandCommandParameter(UserInteractionType userInteractionType, int operandValue)
        {
            UserInteractionType = userInteractionType;
            OperandValue = operandValue;
        }
    }
}
