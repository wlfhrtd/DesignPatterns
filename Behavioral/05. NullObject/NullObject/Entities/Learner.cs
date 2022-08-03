namespace NullObject.Entities
{
    public class Learner : ILearner
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CoursesCompleted { get; private set; }

        public Learner(int id, string name, int coursesCompleted)
        {
            Id = id;
            Name = name;
            CoursesCompleted = coursesCompleted;
        }
    }
}