using Command.Models;
using Command.Repositories;
using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCartRepository shoppingCartRepository = new();
            ProductRepository productRepository = new();

            Product product = productRepository.FindOneByArticleId("SM7B");

            shoppingCartRepository.Add(product);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);
            shoppingCartRepository.IncreaseQuantity(product.ArticleId);

            PrintCart(shoppingCartRepository);
        }

        private static void PrintCart(ShoppingCartRepository shoppingCartRepository)
        {
            decimal total = 0m;

            foreach (var item in shoppingCartRepository.LineItems)
            {
                decimal price = item.Value.Product.Price * item.Value.Quantity;
                Console.WriteLine($"{item.Key} ${item.Value.Product.Price} x {item.Value.Quantity} = ${price}");
                total += price;
            }

            Console.WriteLine($"Total price:\t${total}");
        }
    }
}
