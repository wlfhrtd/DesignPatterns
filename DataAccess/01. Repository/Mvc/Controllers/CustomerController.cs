using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private ShoppingContext context;

        public CustomerController()
        {
            context = new ShoppingContext();
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = context.Customers.ToList();

                return View(customers);
            }
            else
            {
                var customer = context.Customers.Find(id.Value);

                return View(new[] { customer });
            }
        }
    }
}
