using StrategyShipping.Models;


namespace StrategyShipping.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}
