using StrategyAlternative.Models;


namespace StrategyAlternative.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
