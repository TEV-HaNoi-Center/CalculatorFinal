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
    public class FunctionCommandParameter : ICommandParameter
    {
        public UserInteractionType UserInteractionType { get; }

        public FunctionType FunctionType { get; }

        public string FunctionText { get; }

        public FunctionCommandParameter(UserInteractionType userInteractionType, FunctionType functionType)
        {
            UserInteractionType = userInteractionType;

            FunctionType = functionType;
            FunctionText = Functions.GetFunctionText(functionType);
        }
    }
}
