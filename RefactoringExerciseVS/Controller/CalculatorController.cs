﻿using RefactoringExerciseVS.Model;
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
        private readonly ICalculator calculator;

        public CalculatorController(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        public bool UserInput(string input) //Bool-kollen är svår att följa
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                if (Int32.TryParse(input, out var result))
                {
                    this.calculator.AddNumber(result);
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
            return this.calculator.stack.Count();
        }
        public Stack<double> GetStack()
        {
            return this.calculator.stack;
        }

        /* Should i have a input check if the operand that is sent in is valid or not?
         * Or should it return a bool? throw and error? Check others.
         * 
         */
        private bool Calculations(string input)
        {
            bool success = true;
            switch (input) //I will return a bool here. And then maybe use a wrapperclass with a boolean?
            {
                
                case "+":
                    this.calculator.AdditionOperation();
                    break;
                case "-":
                    this.calculator.SubtractOperation();
                    break;
                case "*":
                    this.calculator.MultiplyOperation();
                    break;
                case "/":
                    this.calculator.DivideOperation();
                    break;
                case "c":
                    this.calculator.ClearStack();
                    break;
                default:
                success= false;
                    break;
            }
            return success;
        }

    }
}
