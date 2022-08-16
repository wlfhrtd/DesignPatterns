using RulesEngine.Models;
using System;

namespace RulesEngine.Discounts
{
    public class DiscountCalculator
    {
        // Cyclomatic Complexity == 21
        public decimal CalculateDiscountPercentage(Customer customer)
        {
            bool isBirthday = customer.DateOfBirth.HasValue &&
                customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
                customer.DateOfBirth.Value.Month == DateTime.Today.Month;

            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return 0.15m;
            }
            else
            {
                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
                {
                    if (isBirthday) return 0.25m;
                    return 0.15m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
                {
                    if (isBirthday) return 0.22m;
                    return 0.12m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
                {
                    if (isBirthday) return 0.20m;
                    return 0.10m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2) &&
                    !customer.IsVeteran)
                {
                    if (isBirthday) return 0.18m;
                    return 0.08m;
                }

                if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1) &&
                    !customer.IsVeteran)
                {
                    if (isBirthday) return 0.15m;
                    return 0.05m;
                }
            }

            if (customer.IsVeteran)
            {
                if (isBirthday) return 0.20m;
                return 0.10m;
            }

            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                if (isBirthday) return 0.15m;
                return 0.05m;
            }

            if (isBirthday) return 0.10m;

            return 0;
        }
    }
}
