using RulesEngine.Models;
using System;
using System.Collections.Generic;

namespace RulesEngine.Discounts.RulesEngine
{
    public class DiscountRulesEngine
    {
        List<IDiscountRule> rules = new();


        public DiscountRulesEngine(IEnumerable<IDiscountRule> rulesList)
        {
            rules.AddRange(rulesList);
        }


        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0m;
            foreach (var rule in rules)
            {
                discount = Math.Max(discount, rule.CalculateDiscount(customer, discount));
            }

            return discount;
        }
    }
}
