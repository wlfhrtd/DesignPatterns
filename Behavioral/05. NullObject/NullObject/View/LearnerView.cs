using NullObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.View
{
    public class LearnerView
    {
        private readonly ILearner learner;


        public LearnerView(ILearner l)
        {
            // if (l == null) throw new ArgumentNullException(nameof(l));
            // if (l.Name == null) throw new ArgumentNullException(nameof(l.Name));

            // null checks not needed anymore with implemented Null Object pattern (check LearnerService)
            learner = l;
        }


        public void RenderView()
        {
            Console.WriteLine($"Name: {learner.Name}");
            Console.WriteLine($"Courses Completed: {learner.CoursesCompleted}");
        }
    }
}
