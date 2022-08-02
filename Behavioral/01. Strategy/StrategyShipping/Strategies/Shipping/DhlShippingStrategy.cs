﻿using StrategyShipping.Models;
using System;
using System.Net.Http;


namespace StrategyShipping.Strategies.Shipping
{
    public class DhlShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (HttpClient httpClient = new())
            {
                // api calls

                Console.WriteLine("Order is shipped via DHL.");
            }
        }
    }
}
