namespace Prototype.Models.Prototypes.Order
{
    public abstract class OrderPrototype
    {
        public abstract OrderPrototype ShallowCopy();

        public abstract OrderPrototype DeepCopy();

        public abstract void Print();
    }
}
