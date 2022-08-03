namespace NullObject.Entities
{
    public interface ILearner
    {
        int Id { get; }

        string Name { get; }

        int CoursesCompleted { get; }
    }
}