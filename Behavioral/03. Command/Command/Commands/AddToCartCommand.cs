using Command.Models;
using Command.Repositories;


namespace Command.Commands
{
    public class AddToCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        private readonly IProductRepository productRepository;

        private readonly Product product;

        // it is possible to pass parameters into methods instead of constructor
        // but best practice is to provide Command with everything it needs on construction
        public AddToCartCommand(IShoppingCartRepository cr, IProductRepository pr, Product p)
        {
            shoppingCartRepository = cr;
            productRepository = pr;
            product = p;
        }


        public bool CanExecute()
        {
            return product == null ? false : productRepository.GetStockFor(product.ArticleId) > 0;
        }

        public void Execute()
        {
            if (product == null) return;

            productRepository.DecreaseStockBy(product.ArticleId, 1);
            shoppingCartRepository.Add(product);
        }

        public void Undo()
        {
            if (product == null) return;

            var item = shoppingCartRepository.FindRowByArticleId(product.ArticleId);
            productRepository.IncreaseStockBy(product.ArticleId, item.Quantity);
            shoppingCartRepository.Remove(product.ArticleId);
        }
    }
}
