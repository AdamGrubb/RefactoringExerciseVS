using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExerciseVS.Model
{
    public class StackCalculator : ICalculatorModel
    {
        public Stack<double> stack { get; } = new Stack<double>();
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
