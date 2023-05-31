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
        public void AddNumber(int userNumb)
        {
                stack.Push(userNumb);
        }
        public Stack<double> GetStack() { return stack; }
        public void ClearStack()
        {
            stack.Clear();
        }

        public void AdditionOperation()
        {
            stack.Push(stack.Pop() + stack.Pop());
        }

        public void SubtractOperation()
        {
            double stackTop = stack.Pop();
            stack.Push(stack.Pop() - stackTop);
        }

        public void MultiplyOperation()
        {
            stack.Push(stack.Pop() * stack.Pop());
        }

        public void DivideOperation()
        {
            double stackTop = stack.Pop();
            stack.Push(stack.Pop() - stackTop);
        }
    }
}
