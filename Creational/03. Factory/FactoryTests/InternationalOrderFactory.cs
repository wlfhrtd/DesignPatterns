using AbstractFactory.Models.Commerce;

namespace FactoryTests
{
    public class InternationalOrderFactory : OrderFactory
    {
        protected override Order CreateOrder()
        {
            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Filip Ekberg",
                    Country = "Sweden"
                },
                Sender = new Address
                {
                    To = "Someone else",
                    Country = "Denmark"
                },
                TotalWeight = 100,
            };

            return order;
        }
    }
}
