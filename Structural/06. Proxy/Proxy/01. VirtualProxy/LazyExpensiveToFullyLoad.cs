using System;
using System.Collections.Generic;

namespace Proxy._01._VirtualProxy
{
    public class LazyExpensiveToFullyLoad : BaseClassWithHistory
    {
        private Lazy<IEnumerable<ExpensiveEntity>> homeEntities;
        public IEnumerable<ExpensiveEntity> HomeEntities => homeEntities.Value;

        private Lazy<IEnumerable<ExpensiveEntity>> awayEntities;
        public IEnumerable<ExpensiveEntity> AwayEntities => awayEntities.Value;

        public LazyExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
            homeEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));
            awayEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));
        }
    }
}
