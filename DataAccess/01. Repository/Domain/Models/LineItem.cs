﻿using System;


namespace Domain.Models
{
    public class LineItem
    {
        public Guid LineItemId { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }


        public LineItem()
        {
            LineItemId = Guid.NewGuid();
        }


        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
