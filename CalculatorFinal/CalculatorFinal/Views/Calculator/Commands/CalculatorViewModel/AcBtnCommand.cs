using CalculatorFinal.Core.Commands;
using CalculatorFinal.Views.Calculator.CommandParameters;
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
        private ICommand _acBtnCommand;
        public ICommand AcBtnCommand =>
            _acBtnCommand ?? (_acBtnCommand = new RelayCommandAsync<OperationCommandParameter>(AcBtnCommandExecute));

        public void AcBtnCommandExecute(OperationCommandParameter commandParameter)
        {
            _calculatorStorageService.ClearQueue();
            _calculatorStorageService.ClearStack();
            _calculatorStorageService.ClearLeftParenthesisNumber();

            NumberTextBoxValue = default(int).ToString();
            SeriesOfComputerTextBoxValue = string.Empty;

            _calculatorStorageService.SetLastUserInteractionType(commandParameter.UserInteractionType);
        }
    }
}
