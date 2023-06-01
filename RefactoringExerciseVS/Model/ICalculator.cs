namespace RefactoringExerciseVS.Model
{
    public interface ICalculator
    {
        Stack<double> stack { get; }

        void AddNumber(int userNumb);
        void AdditionOperation();
        void SubtractOperation();
        void MultiplyOperation();
        void DivideOperation();
        void ClearStack();

    }
}