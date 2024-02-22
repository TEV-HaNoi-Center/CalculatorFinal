﻿using CalculatorFinal.Container.Unity;
using CalculatorFinal.Container;
using CalculatorFinal.Core.Enums;
using CalculatorFinal.Core.Exceptions.Models;
using CalculatorFinal.Core.Services.Interfaces;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace CalculatorFinal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IEnvironmentService _environmentService;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.Init();

            _environmentService = DependencyInjector.Retrieve<IEnvironmentService>();

            DependencyInjector.Retrieve<MainWindow>().Show();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Current.DispatcherUnhandledException += AppDispatcherUnhandledException;
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            EnvironmentType environmentType = _environmentService.GetEnvironmentType();
            ErrorModel errorModel = new ErrorModel(environmentType, e.Exception);

            ShowUnhandledException(errorModel);

            e.Handled = true;
        }

        private static void ShowUnhandledException(ErrorModel errorModel)
        {
            string errorMessage = $"An application error occured.\n\n{errorModel.Message}.\n\n{errorModel.Exception}";

            if (MessageBox.Show(errorMessage, "Application Error", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
            {
                Current.Shutdown();
            }
        }
    }

}
