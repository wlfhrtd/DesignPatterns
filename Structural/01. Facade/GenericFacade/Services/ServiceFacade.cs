using System;

namespace GenericFacade.Services
{
    public class ServiceFacade : IServiceFacade
    {
        readonly ServiceA serviceA = new ServiceA();
        readonly ServiceB serviceB = new ServiceB();
        readonly ServiceC serviceC = new ServiceC();

        public Tuple<int, double, string> CallFacade()
        {
            int AResult = serviceA.Method2();
            string BResult = serviceB.Method2();
            double CResult = serviceC.Method1();

            return new(AResult, CResult, BResult);
        }
    }
}
