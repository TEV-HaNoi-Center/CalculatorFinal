﻿using CalculatorFinal.Core.Commands;
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
        private ICommand _squareOfXNumberBtnCommand;
        public ICommand SquareOfXNumberBtnCommand =>
            _squareOfXNumberBtnCommand ?? (_squareOfXNumberBtnCommand = new RelayCommandAsync<OperatorCommandParameter>(SquareOfNumberBtnCommandExecute));

        private void SquareOfNumberBtnCommandExecute(OperatorCommandParameter commandParameter)
        {
            const int SQUARE_VALUE = 2;

            if (_calculatorStorageService.LastUserInteractionType == UserInteractionType.EqualBtnPressed)
            {
                _calculatorStorageService.AddValueToQueue(_calculatorStorageService.Ans.ToString(CultureInfo.CurrentCulture));

                SeriesOfComputerTextBoxValue = $"{Operations.GetOperationText(OperationType.Ans)}";
            }

            if (_calculatorStorageService.LastUserInteractionType != UserInteractionType.AnsBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.EqualBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.EFunctionBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.ModOperatorBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.FactOperatorBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.SquareOfXNumberBtnPressed &&
                _calculatorStorageService.LastUserInteractionType != UserInteractionType.RightParenthesisBtnPressed)
            {
                _calculatorStorageService.AddValueToQueue(NumberTextBoxValue);

                SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {NumberTextBoxValue}";
            }

            _calculatorStorageService.AddValueToQueue(Convert.ToString(SQUARE_VALUE));
            _calculatorStorageService.AddOperatorToStack(commandParameter.OperatorText, commandParameter.OperatorType);

            SeriesOfComputerTextBoxValue = $"{SeriesOfComputerTextBoxValue.Trim()} {commandParameter.OperatorText} {SQUARE_VALUE}";
            NumberTextBoxValue = string.Empty;

            _calculatorStorageService.SetLastUserInteractionType(commandParameter.UserInteractionType);
        }
    }
}