namespace RefactoringExerciseVS.Model
{
    public interface IStack
    {
        void Clear();
        int Count();
        double Pop();
        void Push(double value);
        double[] ListData();
    }
}