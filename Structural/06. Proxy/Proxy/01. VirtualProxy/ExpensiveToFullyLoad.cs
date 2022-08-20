using System.Collections.Generic;

namespace Proxy._01._VirtualProxy
{
    public class ExpensiveToFullyLoad : BaseClassWithHistory
    {
        protected ExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
        }


        public virtual IEnumerable<ExpensiveEntity> HomeEntities { get; protected set; }

        public virtual IEnumerable<ExpensiveEntity> AwayEntities { get; protected set; }

        public static ExpensiveToFullyLoad Create()
        {
            return new VirtualExpensiveToFullyLoad();
        }
    }
}
