using System.Collections.Generic;

namespace Prototype.Models.Prototypes.Order
{
    public class OrderPrototypeManager
    {
        private Dictionary<string, OrderPrototype> prototypes = new();

        public OrderPrototype this[string key]
        {
            get => prototypes[key];

            set => prototypes.Add(key, value);
        }
    }
}
