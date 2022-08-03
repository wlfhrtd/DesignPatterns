using Command.Repositories;
using System;
using System.Linq;


namespace Command.Commands
{
    public class RemoveAllFromCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        private readonly IProductRepository productRepository;


        public RemoveAllFromCartCommand(IShoppingCartRepository cr, IProductRepository pr)
        {
            shoppingCartRepository = cr;
            productRepository = pr;
        }


        public bool CanExecute()
        {
            return shoppingCartRepository.FindAllRows().Any();
        }

        public void Execute()
        {
            var items = shoppingCartRepository.FindAllRows().ToArray();

            foreach (var item in items)
            {
                productRepository.IncreaseStockBy(item.Product.ArticleId, item.Quantity);
                shoppingCartRepository.Remove(item.Product.ArticleId);
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
