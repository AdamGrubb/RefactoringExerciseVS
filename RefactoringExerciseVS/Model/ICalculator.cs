namespace RefactoringExerciseVS.Model
{
    public interface ICalculator
    {
        Stack<double> stack { get; }

        void AddNumber(int userNumb);
        bool AdditionOperation();
        bool SubtractOperation();
        bool MultiplyOperation();
        bool DivideOperation();
        bool ClearStack();

    }
}