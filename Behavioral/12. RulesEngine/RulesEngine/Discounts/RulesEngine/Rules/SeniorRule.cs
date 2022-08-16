using RulesEngine.Models;
using System;

namespace RulesEngine.Discounts.RulesEngine.Rules
{
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
                return 0.05m;

            return 0m;
        }
    }
}
