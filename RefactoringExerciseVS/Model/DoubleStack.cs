using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExerciseVS.Model
{
    class DoubleStack : IStack
    {
        private double[] data;
        private int Depth;

        public DoubleStack()
        {
            data = new double[1000];
            Depth = 0;
        }

        public void Push(double value)
        {
            data[Depth++] = value;
        }

        public double Pop()
        {
            return data[--Depth];
        }
        public void Clear()
        {
            Depth = 0;
        }
        public int Count()
        {
            return Depth;
        }

        public double[] ListData()
        {
            return data;
        }
    }
}
