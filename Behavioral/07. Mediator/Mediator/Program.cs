using Mediator.ChatApp;
using Mediator.Structural;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamChatroom teamChat = new();

            Developer steve = new("Steve");
            Developer justin = new("Justin");
            Developer jenna = new("Jenna");
            Tester kim = new("Kim");
            Tester julia = new("Julia");

            teamChat.RegisterMembers(steve, justin, jenna, kim, julia);

            steve.Send("Hey everyone we're going to deploy at 2pm today.");
            kim.Send("Ok, thanks for letting us know.");

            System.Console.WriteLine();
            steve.SendTo<Developer>("Make sure to run unit tests.");
        }

        private static void Structural()
        {
            ConcreteMediator mediator = new();

            // ORIGINAL
            //Colleague1 c1 = new(mediator);
            //Colleague2 c2 = new(mediator);
            //mediator.Colleague1 = c1;
            //mediator.Colleague2 = c2;

            // EXTENSIBLE
            //Colleague1 c1 = new();
            //Colleague2 c2 = new();
            //mediator.Register(c1);
            //mediator.Register(c2);

            // EXTENSIBLE WITH DELEGATING CREATION OF COLLEAGUES TO MEDIATOR ITSELF
            var c1 = mediator.CreateColleague<Colleague1>();
            var c2 = mediator.CreateColleague<Colleague2>();

            c1.Send("Test message#1 from c1");
            c2.Send("Test message#2 from c2");
        }
    }
}
