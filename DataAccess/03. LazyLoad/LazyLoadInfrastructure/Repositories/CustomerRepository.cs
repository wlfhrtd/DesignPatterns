using LazyLoadDomain.Models;
using LazyLoadInfrastructure.Lazy.Ghosts;
using LazyLoadInfrastructure.Lazy.Proxies;
using System;
using System.Collections.Generic;
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

        // Ghost Object pattern
        public override Customer Get(Guid id)
        {
            var customerId = context.Customers
                .Where(c => c.CustomerId == id)
                .Select(c => c.CustomerId)
                .Single();

            return new GhostCustomer(() => base.Get(id))
            {
                CustomerId = customerId,
            };
        }

        // Virtual Proxy pattern
        private CustomerProxy MapToProxy(Customer customer)
        {
            return new CustomerProxy()
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                ShippingAddress = customer.ShippingAddress,
                City = customer.City,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
            };
        }
        // Virtual Proxy pattern
        public override IEnumerable<Customer> All()
        {
            return base.All().Select(MapToProxy);
        }


        #region for non-proxy(Virtual Proxy pattern) solutions
        //// NTS Value Holder pattern usage
        //public override IEnumerable<Customer> All()
        //{
        //    return base.All().Select(c =>
        //    {
        //        c.ProfilePictureValueHolder = new ValueHolder<byte[]>(parameter =>
        //        {
        //            return ProfilePictureService.GetFor(parameter.ToString());
        //        });

        //        return c;
        //    });
        //}
        //// NTS Value Holder pattern usage
        //public override Customer Get(Guid id)
        //{
        //    Customer customer = base.Get(id);
        //    customer.ProfilePictureValueHolder = new ValueHolder<byte[]>(p =>
        //    {
        //        return ProfilePictureService.GetFor(p.ToString());
        //    });

        //    return customer;
        //}

        //// ThreadSafe Value Holder pattern usage
        //public override IEnumerable<Customer> All()
        //{
        //    return base.All().Select(c =>
        //    {
        //        c.ProfilePictureValueHolder = new Lazy<byte[]>(() =>
        //        {
        //            return ProfilePictureService.GetFor(c.Name);
        //        });

        //        return c;
        //    });
        //}
        //// ThreadSafe Value Holder pattern usage
        //public override Customer Get(Guid id)
        //{
        //    Customer customer = base.Get(id);
        //    customer.ProfilePictureValueHolder = new Lazy<byte[]>(() =>
        //    {
        //        return ProfilePictureService.GetFor(customer.Name);
        //    });

        //    return customer;
        //}
        #endregion
    }
}
