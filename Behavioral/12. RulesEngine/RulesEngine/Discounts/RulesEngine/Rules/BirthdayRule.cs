using RulesEngine.Models;
using System;

namespace RulesEngine.Discounts.RulesEngine.Rules
{
    public class BirthdayRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            bool isBirthday = customer.DateOfBirth.HasValue &&
                customer.DateOfBirth.Value.Day == DateTime.Today.Day &&
                customer.DateOfBirth.Value.Month == DateTime.Today.Month;

            if (isBirthday) return currentDiscount + 0.10m;
            return currentDiscount;
        }
    }
}
