using StrategyShipping.Models;


namespace StrategyShipping.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
