using CalculatorFinal.Core.Commands;
using CalculatorFinal.Views.Calculator.CommandParameters;
using CalculatorFinal.Views.Calculator.Enums;
using CalculatorFinal.Views.Calculator.StaticValues.Enums;
using CalculatorFinal.Views.Calculator.StaticValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorFinal.Views.Calculator.ViewModels
{
    public partial class CalculatorViewModel
    {
        private ICommand _trigonometricFunctionBtnCommand;
        public ICommand TrigonometricFunctionBtnCommand =>
            _trigonometricFunctionBtnCommand ?? (_trigonometricFunctionBtnCommand = new RelayCommandAsync<TrigonometricFunctionCommandParameter>(TrigonometricFunctionBtnCommandExecute));

        private void TrigonometricFunctionBtnCommandExecute(TrigonometricFunctionCommandParameter commandParameter)
        {
            UserInteractionType userOperationType = !_isShiftEnabled ? commandParameter.UserInteractionType : commandParameter.InverseUserInteractionType;

            string trigonometricFunctionText = !_isShiftEnabled ? commandParameter.TrigonometricFunctionText : commandParameter.InverseTrigonometricFunctionText;
            string leftParenthesisOperatorText = Operators.GetOperatorText(OperatorType.LeftParenthesis);

            if (_calculatorStorageService.LastUserInteractionType == UserInteractionType.EqualBtnPressed)
            {
                SeriesOfComputerTextBoxValue = string.Empty;
            }

            if (_calculatorStorageService.LastUserInteractionType == UserInteractionType.AnsBtnPressed ||
                _calculatorStorageService.LastUserInteractionType == UserInteractionType.EFunctionBtnPressed ||
                _calculatorStorageService.LastUserInteractionType == UserInteractionType.ModOperatorBtnPressed ||
                _calculatorStorageService.LastUserInteractionType == UserInteractionType.FactOperatorBtnPressed ||
                _calculatorStorageService.LastUserInteractionType == UserInteractionType.SquareOfXNumberBtnPressed ||
                _calculatorStorageService.LastUserInteractionType == UserInteractionType.RightParenthesisBtnPressed)
            {
                string mulOperatorText = Operators.GetOperatorText(OperatorType.Multiplication);

                _calculatorStorageService.AddOperatorToStack(mulOperatorText, OperatorType.Multiplication);

                SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {mulOperatorText}";
            }

            _calculatorStorageService.AddLeftParenthesisOperatorToStack(leftParenthesisOperatorText);
            _calculatorStorageService.AddFunctionToStack(trigonometricFunctionText);

            SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {trigonometricFunctionText} {leftParenthesisOperatorText}";
            NumberTextBoxValue = default(int).ToString();

            _calculatorStorageService.SetLastUserInteractionType(userOperationType);
        }
    }
}