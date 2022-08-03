using NullObject.Services;
using NullObject.View;


namespace NullObject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LearnerService learnerService = new();
            var learner = learnerService.GetCurrentLearner();

            LearnerView view = new(learner);
            view.RenderView();
        }
    }
}