using StrategyCreatingInvoice.Models;


namespace StrategyCreatingInvoice.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
