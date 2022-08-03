﻿using Command.Models;
using System.Collections.Generic;
using System.Linq;


namespace Command.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Dictionary<string, (Product Product, int Stock)> Products { get; }


        public ProductRepository()
        {
            Products = new Dictionary<string, (Product Product, int Stock)>();
            Add(new Product("EOSR1", "Canon EOS R", 1099), 2);
            Add(new Product("EOS70D", "Canon EOS 70D", 699), 1);
            Add(new Product("ATOMOSNV", "Atomos Ninja V", 799), 0);
            Add(new Product("SM7B", "Shure SM7B", 399), 5);
        }


        public void Add(Product product, int stock)
        {
            Products[product.ArticleId] = (product, stock);
        }

        public void DecreaseStockBy(string articleId, int amount)
        {
            if (!Products.ContainsKey(articleId)) return;

            Products[articleId] =(Products[articleId].Product, Products[articleId].Stock - amount);
        }

        public IEnumerable<Product> FindAll()
        {
            return Products.Select(x => x.Value.Product);
        }

        public Product FindOneByArticleId(string articleId)
        {
            return Products.ContainsKey(articleId) ? Products[articleId].Product : null;
        }

        public int GetStockFor(string articleId)
        {
            return Products.ContainsKey(articleId) ? Products[articleId].Stock : 0;
        }

        public void IncreaseStockBy(string articleId, int amount)
        {
            if (!Products.ContainsKey(articleId)) return;

            Products[articleId] = (Products[articleId].Product, Products[articleId].Stock + amount);
        }
    }
}
