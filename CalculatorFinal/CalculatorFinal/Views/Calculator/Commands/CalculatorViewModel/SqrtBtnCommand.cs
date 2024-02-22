using CalculatorFinal.Core.Commands;
using CalculatorFinal.Views.Calculator.CommandParameters;
using CalculatorFinal.Views.Calculator.Enums;
using CalculatorFinal.Views.Calculator.StaticValues;
using CalculatorFinal.Views.Calculator.StaticValues.Enums;
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
        private ICommand _sqrtBtnCommand;
        public ICommand SqrtBtnCommand =>
            _sqrtBtnCommand ?? (_sqrtBtnCommand = new RelayCommandAsync<FunctionCommandParameter>(SqrtBtnCommandExecute));

        private void SqrtBtnCommandExecute(FunctionCommandParameter commandParameter)
        {
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
            _calculatorStorageService.AddFunctionToStack(commandParameter.FunctionText);

            SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {commandParameter.FunctionText} {leftParenthesisOperatorText}";
            NumberTextBoxValue = default(int).ToString();

            _calculatorStorageService.SetLastUserInteractionType(commandParameter.UserInteractionType);
        }
    }
}