using StrategyShipping.Models;


namespace StrategyShipping.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
