using LazyLoadDomain.Models;
using LazyLoadInfrastructure.Repositories;

namespace LazyLoadInfrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }

        IRepository<Order> OrderRepository { get; }

        IRepository<Product> ProductRepository { get; }

        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext context;


        public UnitOfWork(ShoppingContext shoppingContext)
        {
            context = shoppingContext;
        }


        private IRepository<Customer> customerRepository;
        public IRepository<Customer> CustomerRepository
            => customerRepository ??= new CustomerRepository(context);

        private IRepository<Order> orderRepository;
        public IRepository<Order> OrderRepository
            => orderRepository ??= new OrderRepository(context);

        private IRepository<Product> productRepository;
        public IRepository<Product> ProductRepository
            => productRepository ??= new ProductRepository(context);

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
