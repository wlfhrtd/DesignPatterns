using Command.Models;
using Command.Repositories;
using System;


namespace Command.Commands
{
    public class RemoveFromCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        private readonly IProductRepository productRepository;

        private readonly Product product;


        public RemoveFromCartCommand(IShoppingCartRepository cr, IProductRepository pr, Product p)
        {
            shoppingCartRepository = cr;
            productRepository = pr;
            product = p;
        }


        public bool CanExecute()
        {
            return product == null ? false : shoppingCartRepository.FindRowByArticleId(product.ArticleId).Quantity > 0;
        }

        public void Execute()
        {
            if (product == null) return;

            var item = shoppingCartRepository.FindRowByArticleId(product.ArticleId);
            productRepository.IncreaseStockBy(product.ArticleId, item.Quantity);
            shoppingCartRepository.Remove(product.ArticleId);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
