namespace Flyweight.Interfaces
{
    public interface IDrinkFlyweight
    {
        // Intrinsic state - shared/readonly
        string Name { get; }
        // Extrinsic state
        void Serve(string size);
    }
}
