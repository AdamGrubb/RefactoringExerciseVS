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

        public bool ClearStack()
        {
            stack.Clear();
            return true;
        }

        public bool AdditionOperation()
        {
            return checkStackCount((stackSecond, stackTop) => stackSecond + stackTop);
        }

        public bool SubtractOperation()
        {
            return checkStackCount((stackSecond, stackTop) => stackSecond - stackTop);
        }

        public bool MultiplyOperation()
        {
            return checkStackCount((stackSecond, stackTop) => stackSecond * stackTop);
        }

        public bool DivideOperation()
        {
            return checkStackCount((stackSecond, stackTop) => stackSecond / stackTop);
        }
        private bool checkStackCount(Func<double, double, double> arithmeticOperation) 
        {
            if (stack.Count > 1)
            {
                double stackTop = stack.Pop();
                double stackSecond = stack.Pop();
                stack.Push(arithmeticOperation(stackSecond, stackTop));
                return true;
            }
            else return false;

        }
    }
}
