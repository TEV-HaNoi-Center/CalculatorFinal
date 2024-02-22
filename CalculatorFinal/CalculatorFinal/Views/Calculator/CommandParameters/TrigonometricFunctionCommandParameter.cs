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
    public class TrigonometricFunctionCommandParameter : ICommandParameter
    {
        public UserInteractionType UserInteractionType { get; }

        public UserInteractionType InverseUserInteractionType { get; }

        public TrigonometricFunctionType TrigonometricFunctionType { get; }

        public TrigonometricFunctionType InverseTrigonometricFunctionType { get; }

        public string TrigonometricFunctionText { get; }

        public string InverseTrigonometricFunctionText { get; }

        public TrigonometricFunctionCommandParameter(UserInteractionType userInteractionType, UserInteractionType inverseUserInteractionType,
            TrigonometricFunctionType trigonometricFunctionType, TrigonometricFunctionType inverseTrigonometricFunctionType)
        {
            UserInteractionType = userInteractionType;
            InverseUserInteractionType = inverseUserInteractionType;

            TrigonometricFunctionType = trigonometricFunctionType;
            InverseTrigonometricFunctionType = inverseTrigonometricFunctionType;

            TrigonometricFunctionText = Functions.GetTrigonometricFunctionText(trigonometricFunctionType);
            InverseTrigonometricFunctionText = Functions.GetTrigonometricFunctionText(inverseTrigonometricFunctionType);
        }
    }
}
