using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExerciseVS.Model
{
    public class Calculator : ICalculator
    {
        public Stack<double> stack { get; } = new Stack<double>();
        public void Calculations(string userInput)
        {
            if (Int32.TryParse(userInput, out var result))
            {
                stack.Push(result);
            }
            else
            {
                Calculate(userInput);
            }
        }
        public Stack<double> GetStack() { return stack; }
        private void ClearStack()
        {
            stack.Clear(); //Even here the wrapperclass could return a true and some text that said that it was cleared
        }
        private void Calculate(string userInput)
        {
            if (stack.Count > 1)
            {
                switch (userInput) //I will return a bool here. And then maybe use a wrapperclass with a boolean?
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        stack.Push(stack.Pop() - stack.Pop());
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "/":
                        stack.Push(stack.Pop() / stack.Pop());
                        break;
                    case "c":
                        ClearStack();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
