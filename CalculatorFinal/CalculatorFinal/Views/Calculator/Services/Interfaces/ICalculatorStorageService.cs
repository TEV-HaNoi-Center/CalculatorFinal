using CalculatorFinal.Views.Calculator.Enums;
using CalculatorFinal.Views.Calculator.StaticValues.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Views.Calculator.Services.Interfaces
{
    public interface ICalculatorStorageService
    {
        Queue<string> Queue { get; }

        double Ans { get; }

        int LeftParenthesisNumber { get; }

        UserInteractionType LastUserInteractionType { get; }

        void SetLastUserInteractionType(UserInteractionType userInteractionType);

        void AddValueToQueue(string value);

        void AddOperatorToStack(string inputOperatorText, OperatorType inputOperatorType);

        void AddLeftParenthesisOperatorToStack(string inputOperatorText);

        void AddRightParenthesisOperatorToStack(string inputOperatorText);

        void AddFunctionToStack(string inputFunctionText);

        void AddAllItemsInTheStackToTheQueue();
        
        void SetAns(double ans);

        void ClearQueue();

        void ClearStack();

        void ClearLeftParenthesisNumber();
    }
}
