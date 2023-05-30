namespace RefactoringExerciseVS.Model
{
    public interface ICalculator
    {
        Stack<double> stack { get; }
        void Calculations(string userInput);
        Stack<double> GetStack();
    }
}