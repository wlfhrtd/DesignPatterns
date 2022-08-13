using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Mvc.Controllers
{
    public class CustomerController : Controller
    {
        // strongly bound dependency which should be eliminated with Repository pattern
        //private ShoppingContext context;

        //public CustomerController()
        //{
        //    context = new ShoppingContext();
        //}

        // Repository pattern usage
        private readonly IRepository<Customer> customerRepository;


        public CustomerController(IRepository<Customer> cr)
        {
            customerRepository = cr;
        }

        // old code leveraging EF DbContext directly
        //public IActionResult Index(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        var customers = context.Customers.ToList();

        //        return View(customers);
        //    }
        //    else
        //    {
        //        var customer = context.Customers.Find(id.Value);

        //        return View(new[] { customer });
        //    }
        //}

        // Repository pattern usage
        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = customerRepository.All();

                return View(customers);
            }
            else
            {
                var customer = customerRepository.Get(id.Value);

                return View(new[] { customer });
            }
        }
    }
}
