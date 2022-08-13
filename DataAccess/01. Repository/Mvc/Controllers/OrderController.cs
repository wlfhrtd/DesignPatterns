using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System;
using System.Diagnostics;
using System.Linq;


namespace Mvc.Controllers
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
        private readonly IRepository<Order> orderRepository;

        private readonly IRepository<Product> productRepository;


        public OrderController(IRepository<Order> or, IRepository<Product> pr)
        {
            orderRepository = or;
            productRepository = pr;
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
        public IActionResult Index()
        {
            var orders = orderRepository.Find(o => o.OrderDate > DateTime.UtcNow.AddDays(-1)).ToList();

            return View(orders);
        }

        // old code leveraging EF DbContext directly
        //public IActionResult Create()
        //{
        //    var products = context.Products.ToList();

        //    return View(products);
        //}

        // Repository pattern usage
        public IActionResult Create()
        {
            var products = productRepository.All();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };

            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),
                Customer = customer
            };
            // old code leveraging EF DbContext directly
            //context.Orders.Add(order);
            //context.SaveChanges();

            // Repository pattern usage
            orderRepository.Add(order);

            orderRepository.SaveChanges();

            return Ok("Order Created");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
