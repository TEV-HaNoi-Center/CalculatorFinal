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
    public class FunctionAndOperatorCommandParameter : ICommandParameter
    {
        public UserInteractionType FunctionUserInteractionType { get; }

        public UserInteractionType OperatorUserInteractionType { get; }

        public FunctionType FunctionType { get; }

        public OperatorType OperatorType { get; }

        public string FunctionText { get; }

        public string OperatorText { get; }

        public FunctionAndOperatorCommandParameter(UserInteractionType functionUserInteractionType, UserInteractionType operatorUserInteractionType, FunctionType functionType, OperatorType operatorType)
        {
            FunctionUserInteractionType = functionUserInteractionType;
            OperatorUserInteractionType = operatorUserInteractionType;

            FunctionType = functionType;
            OperatorType = operatorType;

            FunctionText = Functions.GetFunctionText(functionType);
            OperatorText = Operators.GetOperatorText(operatorType);
        }
    }
}
