using AbstractFactory.Models.Commerce.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FactoryProvider
{
    public class PurchaseProviderFactoryProvider
    {
        private IEnumerable<Type> factories;


        public PurchaseProviderFactoryProvider()
        {
            factories = Assembly
                .GetAssembly(typeof(IPurchaseProviderFactory)) // AbstractFactory project
                .GetTypes()
                .Where(t => typeof(IPurchaseProviderFactory)
                .IsAssignableFrom(t));
        }


        public IPurchaseProviderFactory CreateFactoryFor(string name)
        {
            var factory = factories
                .Single(x => x.Name.ToLowerInvariant()
                .Contains(name.ToLowerInvariant()));

            var instance = (IPurchaseProviderFactory)Activator.CreateInstance(factory);

            return instance;
        }
    }
}
