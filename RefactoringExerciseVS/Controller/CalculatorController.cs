using RefactoringExerciseVS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringExerciseVS.Controller
{
    public class CalculatorController
    {
        private readonly ICalculator calculator;

        public CalculatorController(ICalculator calculator) 
        {
            this.calculator = calculator;
        }
        public bool UserInput(string input) 
        {
            if(String.IsNullOrWhiteSpace(input)) 
            {
                return false;
            }
            else
            {
                this.calculator.Calculations(input);
                return true;
            }
            
        }
        public Stack<double> GetStack()
        {
            return this.calculator.stack;
        }

    }
}
