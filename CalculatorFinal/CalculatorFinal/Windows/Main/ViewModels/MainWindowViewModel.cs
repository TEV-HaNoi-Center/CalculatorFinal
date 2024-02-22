using CalculatorFinal.Core.ViewModels;
using CalculatorFinal.Views.Calculator.ViewModels.Interfaces;
using CalculatorFinal.Windows.Main.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public ICalculatorViewModel CalculatorViewModel { get; }

        public MainWindowViewModel(ICalculatorViewModel calculatorViewModel)
        {
            CalculatorViewModel = calculatorViewModel;
        }
    }
}
