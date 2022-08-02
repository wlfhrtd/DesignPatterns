using StrategyCreatingInvoice.Models;


namespace StrategyCreatingInvoice.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
