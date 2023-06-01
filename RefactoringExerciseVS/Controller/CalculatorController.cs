
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExerciseVS.Controller
{
    public class CalculatorController : ICalculatorController
    {
        private Stack<double> stack = new Stack<double>();
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
        public int GetStackCount()
        {
            return stack.Count();
        }
        public Stack<double> GetStack()
        {
            return stack;
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
        public void AddNumber(int userNumb)
        {
            stack.Push(userNumb);
        }

        public void ClearStack()
        {
            stack.Clear();
        }

        public void AdditionOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond + stackTop);
        }

        public void SubtractOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond - stackTop);
        }

        public void MultiplyOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond * stackTop);
        }

        public void DivideOperation()
        {
            checkStackCount((stackSecond, stackTop) => stackSecond / stackTop);
        }
        private void checkStackCount(Func<double, double, double> arithmeticOperation)
        {
            if (stack.Count > 1)
            {
                double stackTop = stack.Pop();
                double stackSecond = stack.Pop();
                stack.Push(arithmeticOperation(stackSecond, stackTop));
            }

        }


    }
}
