using CalculatorFinal.Core.CommandParameters.Interfaces;
using CalculatorFinal.Views.Calculator.Enums;
using CalculatorFinal.Views.Calculator.StaticValues.Enums;
using CalculatorFinal.Views.Calculator.StaticValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Views.Calculator.CommandParameters
{
    public class OperatorCommandParameter : ICommandParameter
    {
        public UserInteractionType UserInteractionType { get; }

        public OperatorType OperatorType { get; }

        public string OperatorText { get; }

        public OperatorCommandParameter(UserInteractionType userInteractionType, OperatorType operatorType)
        {
            UserInteractionType = userInteractionType;
            OperatorType = operatorType;
            OperatorText = Operators.GetOperatorText(operatorType);
        }
    }
}
