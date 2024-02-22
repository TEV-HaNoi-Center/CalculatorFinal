using CalculatorFinal.Core.Extensions;
using CalculatorFinal.Views.Calculator.CommandParameters;
using CalculatorFinal.Views.Calculator.Enums;
using CalculatorFinal.Views.Calculator.StaticValues.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalculatorFinal.Views.Calculator.Converters
{
    public class TrigonometricFunctionCommandParameterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(values), @"The value cannot be null!");
            }

            if (!values.TryIndex(0, out UserInteractionType userInteractionType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(UserInteractionType)} - {nameof(userInteractionType)}");
            }

            if (!values.TryIndex(1, out UserInteractionType inverseUserInteractionType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(UserInteractionType)} - {nameof(inverseUserInteractionType)}");
            }

            if (!values.TryIndex(2, out TrigonometricFunctionType trigonometricFunctionType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(TrigonometricFunctionType)} - {nameof(trigonometricFunctionType)}");
            }

            if (!values.TryIndex(3, out TrigonometricFunctionType inverseTrigonometricFunctionType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(TrigonometricFunctionType)} - {nameof(inverseTrigonometricFunctionType)}");
            }

            return new TrigonometricFunctionCommandParameter(userInteractionType, inverseUserInteractionType, trigonometricFunctionType, inverseTrigonometricFunctionType);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
