using CalculatorFinal.Core.Commands;
using CalculatorFinal.Views.Calculator.CommandParameters;
using CalculatorFinal.Views.Calculator.Enums;
using CalculatorFinal.Views.Calculator.StaticValues.Enums;
using CalculatorFinal.Views.Calculator.StaticValues;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorFinal.Views.Calculator.ViewModels
{
    public partial class CalculatorViewModel
    {
        private ICommand _yRootBtnCommand;
        public ICommand YRootBtnCommand =>
            _yRootBtnCommand ?? (_yRootBtnCommand = new RelayCommandAsync<FunctionCommandParameter>(YRootBtnCommandExecute));

        private void YRootBtnCommandExecute(FunctionCommandParameter commandParameter)
        {
            if (_calculatorStorageService.LastUserInteractionType != UserInteractionType.AnsBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.EFunctionBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.ModOperatorBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.FactOperatorBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.SquareOfXNumberBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.RightParenthesisBtnPressed)
            {
                string leftParenthesisOperatorText = Operators.GetOperatorText(OperatorType.LeftParenthesis);

                if (_calculatorStorageService.LastUserInteractionType == UserInteractionType.EqualBtnPressed)
                {
                    _calculatorStorageService.AddValueToQueue(_calculatorStorageService.Ans.ToString(CultureInfo.CurrentCulture));

                    SeriesOfComputerTextBoxValue = $"{Operations.GetOperationText(OperationType.Ans)}";
                }
                else
                {
                    _calculatorStorageService.AddValueToQueue(NumberTextBoxValue);

                    SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {NumberTextBoxValue}";
                }

                _calculatorStorageService.AddLeftParenthesisOperatorToStack(leftParenthesisOperatorText);
                _calculatorStorageService.AddFunctionToStack(commandParameter.FunctionText);

                SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {commandParameter.FunctionText} {leftParenthesisOperatorText}";
                NumberTextBoxValue = default(int).ToString();

                _calculatorStorageService.SetLastUserInteractionType(commandParameter.UserInteractionType);
            }
        }
    }
}