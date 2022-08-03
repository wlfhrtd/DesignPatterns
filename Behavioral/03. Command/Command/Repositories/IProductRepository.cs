using Command.Models;
using System.Collections.Generic;


namespace Command.Repositories
{
    public interface IProductRepository
    {
        Product FindOneByArticleId(string articleId);

        int GetStockFor(string articleId);

        IEnumerable<Product> FindAll();

        void DecreaseStockBy(string articleId, int amount);

        void IncreaseStockBy(string articleId, int amount);
    }
}
