using LazyLoadDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LazyLoadInfrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext shoppingContext) : base(shoppingContext)
        {
        }


        public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders
                .Include(o => o.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Where(predicate)
                .ToList();
        }

        public override Order Update(Order entity)
        {
            Order order = context.Orders
                .Include(o => o.LineItems)
                .ThenInclude(lineItem => lineItem.Product)
                .Single(o => o.OrderId == entity.OrderId);

            order.OrderDate = entity.OrderDate;
            order.LineItems = entity.LineItems;

            return base.Update(order);
        }
    }
}
