using System.Collections.Generic;

namespace Proxy._01._VirtualProxy
{
    public class VirtualExpensiveToFullyLoad : ExpensiveToFullyLoad
    {
        public override IEnumerable<ExpensiveEntity> AwayEntities
        {
            // NTS
            get => base.AwayEntities ??= ExpensiveDataSource.GetEntities(this);

            protected set => base.AwayEntities = value;
        }

        public override IEnumerable<ExpensiveEntity> HomeEntities
        {
            // NTS
            get => base.HomeEntities ??= ExpensiveDataSource.GetEntities(this);

            protected set => base.HomeEntities = value;
        }
    }
}
