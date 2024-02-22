using CalculatorFinal.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace CalculatorFinal.Views.Calculator.ViewModels
{
    public partial class CalculatorViewModel
    {
        private ICommand _offBtnCommand;
        public ICommand OffBtnCommand =>
            _offBtnCommand ?? (_offBtnCommand = new RelayCommandAsync(OffBtnCommandExecute));

        public Task OffBtnCommandExecute()
        {
            Window mainWindow = Application.Current.MainWindow;

            if (mainWindow == null)
            {
                throw new ArgumentNullException(nameof(mainWindow), @"The value cannot be null!");
            }

            mainWindow.Close();

            return Task.FromResult(true);
        }
    }
}
