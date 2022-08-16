using RulesEngine.Models;
using System;

namespace RulesEngine.Discounts.RulesEngine.Rules
{
    public class LoyalCustomerRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfFirstPurchase.HasValue)
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                    return 0.15m;

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                    return 0.12m;

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                    return 0.10m;

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) &&
                    !customer.IsVeteran)
                    return 0.08m;

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) &&
                    !customer.IsVeteran)
                    return 0.05m;
            }

            return 0m;
        }
    }
}
