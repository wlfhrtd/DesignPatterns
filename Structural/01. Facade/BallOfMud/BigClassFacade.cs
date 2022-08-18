namespace BallOfMud
{
    // decrease clutter, give appropriate name, wrap, control etc
    public class BigClassFacade
    {
        private readonly BigClass bigClass;


        public BigClassFacade()
        {
            bigClass = new BigClass();
            bigClass.SetValueI(0);
        }


        public void IncreaseBy(int numberToAdd)
        {
            bigClass.AddToI(numberToAdd);
        }

        public void DecreaseBy(int numberToSubtract)
        {
            bigClass.AddToI(-numberToSubtract);
        }

        public int GetCurrentValue()
        {
            return bigClass.GetValueA();
        }
    }
}
