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
    public class FunctionAndOperatorCommandParameterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(values), @"The value cannot be null!");
            }

            if (!values.TryIndex(0, out UserInteractionType functionUserInteractionType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(UserInteractionType)} - {nameof(functionUserInteractionType)}");
            }

            if (!values.TryIndex(1, out UserInteractionType operatorUserInteractionType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(UserInteractionType)} - {nameof(operatorUserInteractionType)}");
            }

            if (!values.TryIndex(2, out FunctionType functionType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(FunctionType)} - {nameof(functionType)}");
            }

            if (!values.TryIndex(3, out OperatorType operatorType))
            {
                throw new IndexOutOfRangeException($@"The following type was not defined: {typeof(OperatorType)} - {nameof(operatorType)}");
            }

            return new FunctionAndOperatorCommandParameter(functionUserInteractionType, operatorUserInteractionType, functionType, operatorType);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
