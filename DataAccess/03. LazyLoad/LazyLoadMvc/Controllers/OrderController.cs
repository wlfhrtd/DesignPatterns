using LazyLoadDomain.Models;
using LazyLoadInfrastructure;
using LazyLoadMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace UoWMvc.Controllers
{
    public class OrderController : Controller
    {
        // strongly bound dependency which should be eliminated with Repository pattern
        //private ShoppingContext context;

        //public OrderController()
        //{
        //    context = new ShoppingContext();
        //}

        // Repository pattern usage
        //private readonly IRepository<Order> orderRepository;

        //private readonly IRepository<Product> productRepository;

        //private readonly IRepository<Customer> customerRepository;

        //public OrderController(IRepository<Order> or,
        //                       IRepository<Product> pr,
        //                       IRepository<Customer> cr)
        //{
        //    orderRepository = or;
        //    productRepository = pr;
        //    customerRepository = cr;
        //}

        // UnitOfWork usage
        private readonly IUnitOfWork unitOfWork;


        public OrderController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }


        // old code leveraging EF DbContext directly
        //public IActionResult Index()
        //{
        //    var orders = context.Orders
        //        .Include(order => order.LineItems)
        //        .ThenInclude(lineItem => lineItem.Product)
        //        .Where(order => order.OrderDate > DateTime.UtcNow.AddDays(-1)).ToList();

        //    return View(orders);
        //}

        // Repository pattern usage
        //public IActionResult Index()
        //{
        //    var orders = orderRepository.Find(o => o.OrderDate > DateTime.UtcNow.AddDays(-1)).ToList();

        //    return View(orders);
        //}

        // UnitOfWork usage
        public IActionResult Index()
        {
            var orders = unitOfWork.OrderRepository
                .Find(o => o.OrderDate > DateTime.UtcNow.AddDays(-1)).ToList();

            return View(orders);
        }

        // old code leveraging EF DbContext directly
        //public IActionResult Create()
        //{
        //    var products = context.Products.ToList();

        //    return View(products);
        //}

        // Repository pattern usage
        //public IActionResult Create()
        //{
        //    var products = productRepository.All();

        //    return View(products);
        //}

        // UnitOfWork usage
        public IActionResult Create()
        {
            var products = unitOfWork.ProductRepository.All();

            return View(products);
        }

        //[HttpPost]
        //public IActionResult Create(CreateOrderModel model)
        //{
        //    if (!model.LineItems.Any()) return BadRequest("Please submit line items");

        //    if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

        //    // currently both - CustomerRepository and OrderRepository
        //    // have different DbContext instances so it will throw exception on SaveChanges()
        //    // could solve it by passing CustomerId only into new Order
        //    // instead of loading Customer from db but it's not about UoW;
        //    // also 2 repositories will trigger 2 sql queries
        //    // so here comes UnitOfWork pattern
        //    Customer customer = customerRepository
        //        .Find(c => c.Name == model.Customer.Name)
        //        .FirstOrDefault();

        //    if (customer != null)
        //    {
        //        customer.ShippingAddress = model.Customer.ShippingAddress;
        //        customer.PostalCode = model.Customer.PostalCode;
        //        customer.City = model.Customer.City;
        //        customer.Country = model.Customer.Country;

        //        customerRepository.Update(customer);
        //        customerRepository.SaveChanges();
        //    }
        //    else
        //    {
        //        customer = new Customer
        //        {
        //            Name = model.Customer.Name,
        //            ShippingAddress = model.Customer.ShippingAddress,
        //            City = model.Customer.City,
        //            PostalCode = model.Customer.PostalCode,
        //            Country = model.Customer.Country
        //        };
        //    }

        //    var order = new Order
        //    {
        //        LineItems = model.LineItems
        //            .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
        //            .ToList(),
        //        Customer = customer
        //    };
        //    // old code leveraging EF DbContext directly
        //    //context.Orders.Add(order);
        //    //context.SaveChanges();

        //    // Repository pattern usage
        //    orderRepository.Add(order);

        //    orderRepository.SaveChanges();

        //    return Ok("Order Created");
        //}

        // UnitOfWork usage
        // UoW lets work with different entities/repositories same time
        // in transactional way - less chatty with db;
        // also do not need to care about instances of context etc
        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            Customer customer = unitOfWork.CustomerRepository
                .Find(c => c.Name == model.Customer.Name)
                .FirstOrDefault();

            if (customer != null)
            {
                customer.ShippingAddress = model.Customer.ShippingAddress;
                customer.PostalCode = model.Customer.PostalCode;
                customer.City = model.Customer.City;
                customer.Country = model.Customer.Country;

                unitOfWork.CustomerRepository.Update(customer);
                // customerRepository.SaveChanges(); now with UoW call save only once from UoW itself
            }
            else
            {
                customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };
            }

            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),
                Customer = customer
            };

            unitOfWork.OrderRepository.Add(order);

            // orderRepository.SaveChanges(); // call SaveChanges() from UoW now (once ofc)
            unitOfWork.SaveChanges();

            return Ok("Order Created");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
