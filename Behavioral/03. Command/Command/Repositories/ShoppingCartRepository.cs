using Command.Models;
using System.Collections.Generic;


namespace Command.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public Dictionary<string, (Product Product, int Quantity)> LineItems = new();

        public void Add(Product product)
        {
            if (LineItems.ContainsKey(product.ArticleId))
            {
                IncreaseQuantity(product.ArticleId);
                return;
            }

            LineItems[product.ArticleId] = (product, 1);
        }

        public void DecreaseQuantity(string articleId)
        {
            if (!LineItems.ContainsKey(articleId)) throw new KeyNotFoundException(
                $"Product with id {articleId} is not in cart, please add first.");

            var lineItem = LineItems[articleId];

            if (lineItem.Quantity == 1)
            {
                LineItems.Remove(articleId);
                return;
            }

            LineItems[articleId] = (lineItem.Product, lineItem.Quantity - 1);
        }

        public IEnumerable<(Product Product, int Quantity)> FindAllRows()
        {
            return LineItems.Values;
        }

        public (Product Product, int Quantity) FindRowByArticleId(string articleId)
        {
            return LineItems.ContainsKey(articleId) ? LineItems[articleId] : (default, default);
        }

        public void IncreaseQuantity(string articleId)
        {
            if (!LineItems.ContainsKey(articleId)) throw new KeyNotFoundException(
                 $"Product with id {articleId} is not in cart, please add first.");

            var lineItem = LineItems[articleId];
            LineItems[articleId] = (lineItem.Product, lineItem.Quantity + 1);
        }

        public void Remove(string articleId)
        {
            LineItems.Remove(articleId);
        }
    }
}
