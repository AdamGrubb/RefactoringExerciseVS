
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
        public bool UserInput(string input) //Bool-kollen är svår att följa
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                if (Int32.TryParse(input, out var result))
                {
                    AddNumber(result);
                    return true;
                }
                else
                {
                    return Calculations(input);
                }

            }
            return false;
        }
        private int GetStackCount()
        {
            return stack.Count();
        }
        private bool Calculations(string input)
        {
            bool success = true;
            switch (input) //I will return a bool here. And then maybe use a wrapperclass with a boolean?
            {
                
                case "+":
                    AdditionOperation();
                    break;
                case "-":
                    SubtractOperation();
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
                success= false;
                    break;
            }
            return success;
        }
        private void AddNumber(int userNumb)
        {
            stack.Push(userNumb);
        }

        private void ClearStack()
        {
            stack.Clear();
        }

        private void AdditionOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond + stackTop);
        }

        private void SubtractOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond - stackTop);
        }

        private void MultiplyOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond * stackTop);
        }

        private void DivideOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond / stackTop);
        }
        private void checkStackCount(Func<double, double, double> arithmeticOperation)
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
                    calculatorView.Output(printStack());
                    }
                    var success = UserInput(calculatorView.Input());
                    if (!success)
                    {
                    calculatorView.Output("Invalid input");
                    }

                }
        }
        private string printStack() //Works, but need refactor.
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
