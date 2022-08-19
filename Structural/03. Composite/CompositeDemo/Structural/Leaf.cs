using System;

namespace CompositeDemo.Structural
{
    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }


        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
        }
    }
}
