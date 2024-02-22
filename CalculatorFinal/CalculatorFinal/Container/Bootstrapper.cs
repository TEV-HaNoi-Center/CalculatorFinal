using CalculatorFinal.Container.Unity;
using CalculatorFinal.Core.Services;
using CalculatorFinal.Core.Services.Interfaces;
using CalculatorFinal.Views.Calculator.Services;
using CalculatorFinal.Views.Calculator.Services.Interfaces;
using CalculatorFinal.Views.Calculator.ViewModels;
using CalculatorFinal.Views.Calculator.ViewModels.Interfaces;
using CalculatorFinal.Windows.Main.ViewModels;
using CalculatorFinal.Windows.Main.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Container
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            DependencyInjector.RegisterSingleton<IEnvironmentService, EnvironmentService>();

            DependencyInjector.RegisterTransient<ICalculatorStorageService, CalculatorStorageService>();
            DependencyInjector.RegisterTransient<ICalculateService, CalculateService>();

            DependencyInjector.RegisterTransient<IMainWindowViewModel, MainWindowViewModel>();
            DependencyInjector.RegisterTransient<ICalculatorViewModel, CalculatorViewModel>();
        }
    }
}

