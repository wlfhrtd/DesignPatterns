using RulesEngine.Models;

namespace RulesEngine.Discounts.RulesEngine.Rules
{
    public class VeteranRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.IsVeteran)
                return 0.10m;

            return 0m;
        }
    }
}
