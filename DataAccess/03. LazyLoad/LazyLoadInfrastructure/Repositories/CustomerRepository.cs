using LazyLoadDomain.Models;
using System.Linq;

namespace LazyLoadInfrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext shoppingContext) : base(shoppingContext)
        {
        }


        public override Customer Update(Customer entity)
        {
            Customer customer = context.Customers.Single(c => c.CustomerId == entity.CustomerId);

            customer.Name = entity.Name;
            customer.City = entity.City;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.Country = entity.Country;

            return base.Update(customer);
        }
    }
}
