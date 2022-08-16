using RulesEngine.Models;

namespace RulesEngine.Discounts.RulesEngine.Rules
{
    public class FirstTimeCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (!customer.DateOfFirstPurchase.HasValue)
                return 0.15m;

            return 0m;
        }
    }
}
