using System.Linq;
using UoWDomain.Models;

namespace UoWInfrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShoppingContext shoppingContext) : base(shoppingContext)
        {
        }


        public override Product Update(Product entity)
        {
            Product product = context.Products.Single(p => p.ProductId == entity.ProductId);

            product.Price = entity.Price;
            product.Name = entity.Name;

            return base.Update(product);
        }
    }
}
