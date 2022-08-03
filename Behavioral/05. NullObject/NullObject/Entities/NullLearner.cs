using System;


namespace NullObject.Entities
{
    public class NullLearner : ILearner
    {
        public int Id => -1;

        public string Name => "New User";

        public int CoursesCompleted => 0;
    }
}
