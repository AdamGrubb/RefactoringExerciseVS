
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactoringExerciseVS.Model;
using RefactoringExerciseVS.View;

namespace RefactoringExerciseVS.Controller
{
    public class CalculatorController
    {

        private readonly ICalculatorView calculatorView;
        private readonly IStack stack;

        public CalculatorController(ICalculatorView calculatorView, IStack stack)
        {
            this.calculatorView = calculatorView;
            this.stack = stack;
        }
        public bool ValidateInput(string input)
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                if (Int32.TryParse(input, out var result))
                {
                    AddNumberToStack(result);
                    return true;
                }
                else
                {
                    return CalculatorMethods(input);
                }

            }
            return false;
        }
        private int GetStackCount()
        {
            return stack.Count();
        }
        private bool CalculatorMethods(string input)
        {
            bool IsValidInput = true;
            switch (input)
            {

                case "+":
                    AdditionOperation();
                    break;
                case "-":
                    SubtractionOperation();
                    break;
                case "*":
                    MultiplyOperation();
                    break;
                case "/":
                    DivideOperation();
                    break;
                case "c":
                    ClearStack();
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    IsValidInput = false;
                    break;
            }
            return IsValidInput;
        }
        private void AddNumberToStack(int userNumb)
        {
            stack.Push(userNumb);
        }

        private void ClearStack()
        {
            stack.Clear();
        }

        private void AdditionOperation()
        {
            ValidateStackCount((stackSecond, stackTop) => stackSecond + stackTop);
        }

        private void SubtractionOperation()
        {
            ValidateStackCount((stackSecond, stackTop) => stackSecond - stackTop);
        }

        private void MultiplyOperation()
        {
            ValidateStackCount((stackSecond, stackTop) => stackSecond * stackTop);
        }

        private void DivideOperation()
        {
            ValidateStackCount((stackSecond, stackTop) => stackSecond / stackTop);
        }
        private void ValidateStackCount(Func<double, double, double> arithmeticOperation)
        {
            if (stack.Count() > 1)
            {
                double stackTop = stack.Pop();
                double stackSecond = stack.Pop();
                stack.Push(arithmeticOperation(stackSecond, stackTop));
            }

        }

        public void Start()
        {
            while (true)
            {
                if (GetStackCount() == 0)
                {
                    calculatorView.Output("Commands: q c + - * / number");
                    calculatorView.Output("[]");
                }
                else
                {
                    calculatorView.Output(ArrayToString());
                }
                var success = ValidateInput(calculatorView.Input());
                if (!success)
                {
                    calculatorView.Output("Invalid input");
                }

            }
        }
        private string ArrayToString()
        {
            var stackStack = stack.ListData();
            StringBuilder stackToString = new StringBuilder();
            stackToString.Append('[');
            for (int i = stack.Count() - 1; ; i--)
            {
                stackToString.Append(stackStack[i]);
                if (i == 0)
                    return stackToString.Append(']').ToString();
                stackToString.Append(", ");
            }
        }
    }
}
