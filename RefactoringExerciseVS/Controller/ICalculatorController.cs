namespace RefactoringExerciseVS.Controller
{
    public interface ICalculatorController
    {
        int GetStackCount();
        Stack<double> GetStack();
        bool UserInput(string input);
    }
}