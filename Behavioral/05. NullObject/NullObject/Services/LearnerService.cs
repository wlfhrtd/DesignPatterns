using NullObject.Entities;


namespace NullObject.Services
{
    public class LearnerService
    {
        private readonly LearnerRepository learnerRepository = new();

        public ILearner GetCurrentLearner()
        {
            // user id from some source; from cookie for example
            int learnerId = 4;
            var learner = learnerRepository.FindOneById(learnerId);

            // return learner ?? throw new NullReferenceException(nameof(learner));

            // using Null Object pattern
            return learner ?? new NullLearner();
        }
    }
}
