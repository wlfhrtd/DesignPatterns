using RulesEngine.Discounts.RulesEngine;
using RulesEngine.Discounts.RulesEngine.Rules;
using RulesEngine.Models;
using System.Collections.Generic;

namespace RulesEngine.Discounts
{
    public class DiscountCalculatorRefactored
    {
        #region Extracted to rules
        //private decimal CalculateDiscountForFirstTimeCustomer(Customer customer)
        //{
        //    // 1)
        //    //if (!customer.DateOfFirstPurchase.HasValue)
        //    //    return 0.15m;

        //    //return 0m;

        //    // 2)
        //    return new FirstTimeCustomerRule().CalculateDiscount(customer);
        //}

        //private decimal CalculateDiscountForLoyalCustomer(Customer customer)
        //{
        //    // 1)
        //    //if (customer.DateOfFirstPurchase.HasValue)
        //    //{
        //    //    if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
        //    //        return 0.15m;

        //    //    if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
        //    //        return 0.12m;

        //    //    if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
        //    //        return 0.10m;

        //    //    if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) &&
        //    //        !customer.IsVeteran)
        //    //        return 0.08m;

        //    //    if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) &&
        //    //        !customer.IsVeteran)
        //    //        return 0.05m;
        //    //}

        //    //return 0m;

        //    // 2)
        //    return new LoyalCustomerRule().CalculateDiscount(customer);
        //}

        //private decimal CalculateDiscountForVeteran(Customer customer)
        //{
        //    // 1)
        //    //if (customer.IsVeteran)
        //    //    return 0.10m;

        //    //return 0m;

        //    // 2)
        //    return new VeteranRule().CalculateDiscount(customer);
        //}

        //private decimal CalculateDiscountForSeniors(Customer customer)
        //{
        //    // 1)
        //    //if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
        //    //    return 0.05m;

        //    //return 0m;

        //    // 2)
        //    return new SeniorRule().CalculateDiscount(customer);
        //}

        //private decimal CalculateDiscountForBirthday(Customer customer, decimal currentDiscount)
        //{
        //    // 1)
        //    //bool isBirthday = customer.DateOfBirth.HasValue &&
        //    //    customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
        //    //    customer.DateOfBirth.Value.Month == DateTime.Today.Month;

        //    //if (isBirthday) return currentDiscount + 0.10m;
        //    //return currentDiscount;

        //    // 2)
        //    return new BirthdayRule().CalculateDiscount(customer, currentDiscount);
        //}
        #endregion
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            // decimal discount = 0m;

            // 1)
            //discount = Math.Max(discount, CalculateDiscountForFirstTimeCustomer(customer));
            //discount = Math.Max(discount, CalculateDiscountForLoyalCustomer(customer));
            //discount = Math.Max(discount, CalculateDiscountForVeteran(customer));
            //discount = Math.Max(discount, CalculateDiscountForSeniors(customer));
            //discount = Math.Max(discount, CalculateDiscountForBirthday(customer, discount));

            // 2)
            //discount = Math.Max(discount, new FirstTimeCustomerRule().CalculateDiscount(customer, discount));
            //discount = Math.Max(discount, new LoyalCustomerRule().CalculateDiscount(customer, discount));
            //discount = Math.Max(discount, new VeteranRule().CalculateDiscount(customer, discount));
            //discount = Math.Max(discount, new SeniorRule().CalculateDiscount(customer, discount));
            //discount = Math.Max(discount, new BirthdayRule().CalculateDiscount(customer, discount));

            // apply Rules Engine

            // regular
            List<IDiscountRule> rules = new();
            rules.Add(new FirstTimeCustomerRule());
            rules.Add(new LoyalCustomerRule());
            rules.Add(new VeteranRule());
            rules.Add(new SeniorRule());
            rules.Add(new BirthdayRule());

            // with Reflection services (for stateless rules)
            //var ruleType = typeof(IDiscountRule);
            //IEnumerable<IDiscountRule> rules = this.GetType().Assembly.GetTypes()
            //    .Where(t => ruleType.IsAssignableFrom(t) && !t.IsInterface)
            //    .Select(r => Activator.CreateInstance(r) as IDiscountRule);

            DiscountRulesEngine engine = new(rules);

            return engine.CalculateDiscountPercentage(customer);
        }
    }
}
