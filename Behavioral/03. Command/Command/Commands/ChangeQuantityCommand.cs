using Command.Models;
using Command.Repositories;


namespace Command.Commands
{
    public class ChangeQuantityCommand : ICommand
    {
        public enum Operation { Increase, Decrease, }

        private readonly Operation operation;

        private readonly IShoppingCartRepository shoppingCartRepository;

        private readonly IProductRepository productRepository;

        private readonly Product product;


        public ChangeQuantityCommand(Operation op, IShoppingCartRepository cr, IProductRepository pr, Product p)
        {
            operation = op;
            shoppingCartRepository = cr;
            productRepository = pr;
            product = p;
        }


        public bool CanExecute()
        {
            return operation switch
            {
                Operation.Increase => productRepository.GetStockFor(product.ArticleId) - 1 >= 0,
                Operation.Decrease => shoppingCartRepository.FindRowByArticleId(product.ArticleId).Quantity != 0,
                _ => false,
            };
        }

        public void Execute()
        {
            switch (operation)
            {
                case Operation.Increase:
                    productRepository.DecreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.IncreaseQuantity(product.ArticleId);
                    break;
                case Operation.Decrease:
                    productRepository.IncreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.DecreaseQuantity(product.ArticleId);
                    break;
            }
        }

        public void Undo()
        {
            switch (operation)
            {
                case Operation.Increase:
                    productRepository.IncreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.DecreaseQuantity(product.ArticleId);
                    break;
                case Operation.Decrease:
                    productRepository.DecreaseStockBy(product.ArticleId, 1);
                    shoppingCartRepository.IncreaseQuantity(product.ArticleId);
                    break;
            }
        }
    }
}
