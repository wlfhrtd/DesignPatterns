﻿using System.Collections.Generic;


namespace Mvc.Models
{
    public class CreateOrderModel
    {
        public IEnumerable<LineItemModel> LineItems { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
