using Command.Models;
using System.Collections.Generic;


namespace Command.Repositories
{
    public interface IShoppingCartRepository
    {
        (Product Product, int Quantity) FindRowByArticleId(string articleId);

        IEnumerable<(Product Product, int Quantity)> FindAllRows();

        void Add(Product product);

        void Remove(string articleId);

        void IncreaseQuantity(string articleId);

        void DecreaseQuantity(string articleId);
    }
}
