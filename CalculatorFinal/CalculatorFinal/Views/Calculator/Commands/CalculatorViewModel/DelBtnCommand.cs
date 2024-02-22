using CalculatorFinal.Core.Commands;
using CalculatorFinal.Core.Extensions;
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
        private ICommand _delBtnCommand;
        public ICommand DelBtnCommand =>
            _delBtnCommand ?? (_delBtnCommand = new RelayCommandAsync<OperationCommandParameter>(DelBtnCommandExecute));

        public void DelBtnCommandExecute(OperationCommandParameter commandParameter)
        {
            if (_calculatorStorageService.LastUserInteractionType != UserInteractionType.AnsBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.EqualBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.EFunctionBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.ModOperatorBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.FactOperatorBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.SquareOfXNumberBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.RightParenthesisBtnPressed)
            {
                if (!NumberTextBoxValue.IsOnlyZeroValue())
                {
                    NumberTextBoxValue = NumberTextBoxValue.RemoveLast();

                    if (NumberTextBoxValue.Length == 0)
                    {
                        NumberTextBoxValue = default(int).ToString();
                    }
                }

                _calculatorStorageService.SetLastUserInteractionType(commandParameter.UserInteractionType);
            }
        }
    }
}