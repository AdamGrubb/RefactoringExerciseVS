using RefactoringExerciseVS.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExerciseVS.View
{
    public class ConsoleCalculator : ICalculatorView
    {
        public string Input()
        {
            return Console.ReadLine();
        }
        public void Output(string outPut)
        {
            Console.WriteLine(outPut);
        }
    }


}
