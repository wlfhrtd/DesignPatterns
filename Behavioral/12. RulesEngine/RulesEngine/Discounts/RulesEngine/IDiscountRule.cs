using RulesEngine.Models;

namespace RulesEngine.Discounts.RulesEngine
{
    public interface IDiscountRule
    {
        // Evaluate()
        decimal CalculateDiscount(Customer customer, decimal currentDiscount);
        // alternate RE structure contains
        //   bool IsMatch(Context context)
        // calling before rule apply
    }
}
