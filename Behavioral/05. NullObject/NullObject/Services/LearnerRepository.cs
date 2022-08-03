using NullObject.Entities;
using System.Collections.Generic;
using System.Linq;


namespace NullObject.Services
{
    public class LearnerRepository
    {
        private readonly IList<Learner> learners;


        public LearnerRepository()
        {
            learners = new List<Learner>();
            learners.Add(new Learner(1, "David", 83));
            learners.Add(new Learner(2, "Julie", 72));
            learners.Add(new Learner(3, "Scott", 92));
        }


        public ILearner FindOneById(int id)
        {
            return learners.Any(l => l.Id == id) ? learners.FirstOrDefault(l => l.Id == id) : null;
        }
    }
}
