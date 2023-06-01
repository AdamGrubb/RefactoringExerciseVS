using RefactoringExerciseVS.Controller;
using RefactoringExerciseVS.Model;
using System.Text;

Calculator calculator = new Calculator();
CalculatorController controller = new CalculatorController(calculator);

while (true)
{
    if (controller.GetStackCount() == 0)
    {
        Console.WriteLine("Commands: q c + - * / number");
        Console.WriteLine("[]");
    }
    else
    {
        Console.WriteLine(printStack());
    }
    var success = controller.UserInput(Console.ReadLine());
    if (!success)
    {
        Console.WriteLine("Invalid input");
    }
    
}
string printStack() //Works, but need refactor.
{
    var stackStack = calculator.stack.ToList();
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