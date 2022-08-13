using Microsoft.AspNetCore.Mvc;
using System;
using UoWDomain.Models;
using UoWInfrastructure.Repositories;

namespace UoWMvc.Controllers
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

        // haven't brought UoW just to be more specific about repository usage;
        // do not bring whole big UoW if not needed
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
