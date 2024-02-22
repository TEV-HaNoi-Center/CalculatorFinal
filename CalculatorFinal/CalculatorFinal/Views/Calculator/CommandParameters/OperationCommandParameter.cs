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
    public class OperationCommandParameter : ICommandParameter
    {
        public UserInteractionType UserInteractionType { get; }

        public OperationType OperationType { get; }

        public string OperationText { get; }

        public OperationCommandParameter(UserInteractionType userInteractionType, OperationType operationType)
        {
            UserInteractionType = userInteractionType;
            OperationType = operationType;
            OperationText = Operations.GetOperationText(operationType);
        }
    }
}
