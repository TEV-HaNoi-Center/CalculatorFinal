using CalculatorFinal.Core.Commands;
using CalculatorFinal.Views.Calculator.CommandParameters;
using CalculatorFinal.Views.Calculator.Enums;
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
        private ICommand _rightParenthesisBtnCommand;
        public ICommand RightParenthesisBtnCommand =>
            _rightParenthesisBtnCommand ?? (_rightParenthesisBtnCommand = new RelayCommandAsync<OperatorCommandParameter>(RightParenthesisBtnCommandExecute));

        private void RightParenthesisBtnCommandExecute(OperatorCommandParameter commandParameter)
        {
            if (_calculatorStorageService.LeftParenthesisNumber > 0)
            {
                if (_calculatorStorageService.LastUserInteractionType != UserInteractionType.AnsBtnPressed &&
                    _calculatorStorageService.LastUserInteractionType != UserInteractionType.EFunctionBtnPressed &&
                    _calculatorStorageService.LastUserInteractionType != UserInteractionType.ModOperatorBtnPressed &&
                    _calculatorStorageService.LastUserInteractionType != UserInteractionType.FactOperatorBtnPressed &&
                    _calculatorStorageService.LastUserInteractionType != UserInteractionType.SquareOfXNumberBtnPressed &&
                    _calculatorStorageService.LastUserInteractionType != UserInteractionType.RightParenthesisBtnPressed)
                {
                    _calculatorStorageService.AddValueToQueue(NumberTextBoxValue);

                    SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {NumberTextBoxValue}";
                }

                _calculatorStorageService.AddRightParenthesisOperatorToStack(commandParameter.OperatorText);

                SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {commandParameter.OperatorText}";
                NumberTextBoxValue = string.Empty;

                _calculatorStorageService.SetLastUserInteractionType(commandParameter.UserInteractionType);
            }
        }
    }
}
