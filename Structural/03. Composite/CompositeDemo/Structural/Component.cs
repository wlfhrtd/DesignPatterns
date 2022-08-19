namespace CompositeDemo.Structural
{
    // might be leaf or another composite/node
    public abstract class Component
    {
        public string Name { get; }

        protected Component(string name)
        {
            Name = name;
        }


        public abstract void PrimaryOperation(int depth);
    }
}
