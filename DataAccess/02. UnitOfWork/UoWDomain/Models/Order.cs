using System;
using System.Collections.Generic;
using System.Linq;


namespace UoWDomain.Models
{
    public class Order
    {
        public Guid OrderId { get; private set; }

        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderTotal => LineItems.Sum(item => item.Product.Price * item.Quantity);


        public Order()
        {
            OrderId = Guid.NewGuid();

            OrderDate = DateTime.UtcNow;
        }


        public virtual ICollection<LineItem> LineItems { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
