using RefactoringExerciseVS.Controller;
using RefactoringExerciseVS.View;
using System.Text;

CalculatorController controller = new CalculatorController();
ConsoleCalculator view = new ConsoleCalculator(controller);
view.Start();

