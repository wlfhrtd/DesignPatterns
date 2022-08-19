using System;
using System.Collections.Generic;

namespace CompositeDemo.Structural
{
    // ~node
    public class Composite : Component
    {
        private List<Component> children = new();

        public Composite(string name) : base(name)
        {
        }


        public void Add(Component component)
        {
            children.Add(component);
        }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
            foreach (var component in children)
            {
                component.PrimaryOperation(depth + 2);
            }
        }

        public void Remove(Component component)
        {
            children.Remove(component);
        }
    }
}
