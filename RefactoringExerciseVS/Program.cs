using RefactoringExerciseVS.Controller;
using RefactoringExerciseVS.Model;
using RefactoringExerciseVS.View;
using System.Text;

ConsoleCalculator consoleCalculator = new ConsoleCalculator();
DoubleStack doubleStack = new DoubleStack();
NormalStack normalStack = new NormalStack();
CalculatorController calculatorController = new CalculatorController(consoleCalculator, doubleStack);
calculatorController.Start();

