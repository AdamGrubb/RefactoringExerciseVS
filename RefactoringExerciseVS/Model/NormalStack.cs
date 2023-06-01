using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RefactoringExerciseVS.Model
{
    public class NormalStack : IStack
    {
        private Stack<double> stack = new Stack<double>();
        public void Clear()
        {
            stack.Clear();
        }

        public int Count()
        {
            return stack.Count();
        }

        public double Pop()
        {
            return stack.Pop();
        }

        public double[] ListData()
        {
            return stack.Reverse().ToArray();
        }

        public void Push(double value)
        {
            stack.Push(value);
        }
    }
}
