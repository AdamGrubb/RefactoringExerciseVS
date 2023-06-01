using RefactoringExerciseVS.Controller;
using RefactoringExerciseVS.Model;
using RefactoringExerciseVS.View;
using System.Text;

StackCalculator calculator = new StackCalculator();
CalculatorController controller = new CalculatorController(calculator);
ConsoleCalculator view = new ConsoleCalculator(controller);
view.Start();

