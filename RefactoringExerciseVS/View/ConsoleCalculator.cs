using RefactoringExerciseVS.Controller;
using RefactoringExerciseVS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExerciseVS.View
{
    public class ConsoleCalculator : IConsoleCalculator
    {
        private readonly ICalculatorController calculatorController;

        public ConsoleCalculator(ICalculatorController calculatorController)
        {
            this.calculatorController = calculatorController;
        }
        public void Start()
        {
            while (true)
            {
                if (this.calculatorController.GetStackCount() == 0)
                {
                    Output("Commands: q c + - * / number");
                    Output("[]");
                }
                else
                {
                    Output(printStack());
                }
                var success = calculatorController.UserInput(Input());
                if (!success)
                {
                    Console.WriteLine("Invalid input");
                }

            }


        }
        public string Input()
        {
            return Console.ReadLine();
        }
        public void Output(string outPut)
        {
            Console.WriteLine(outPut);
        }
        private string printStack() //Works, but need refactor.
        {
            var stackStack = calculatorController.GetStack().ToList();
            StringBuilder stackToString = new StringBuilder();
            stackToString.Append('[');
            for (int i = 0; i < stackStack.Count; i++)
            {
                stackToString.Append(stackStack[i]);
                if (i != stackStack.Count - 1) stackToString.Append(", ");
            }
            stackToString.Append(']');
            return stackToString.ToString();
        }
    }


}
