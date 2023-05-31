using RefactoringExerciseVS.Controller;
using RefactoringExerciseVS.Model;
using System.Text;

Calculator calculator = new Calculator();
CalculatorController controller = new CalculatorController(calculator);

while (true)
{
    if (controller.GetStack().Count == 0)
    {
        Console.WriteLine("Commands: q c + - * / number");
        Console.WriteLine("[]");
    }
    else
    {
        Console.WriteLine(controller.printStack());
    }
    var success = controller.UserInput(Console.ReadLine().Trim());
    if (!success)
    {
        Console.WriteLine("Invalid input");
    }
    
}