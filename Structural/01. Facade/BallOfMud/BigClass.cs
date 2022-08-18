namespace BallOfMud
{
    public class BigClass
    {
        private int i;

        public int GetValueA()
        {
            return i;
        }

        public string GetValueB()
        {
            return "Ball of Mud";
        }

        public void SetValueI(int value)
        {
            i = value;
        }

        public void IncrementI()
        {
            i++;
        }

        public void DoSomething()
        {
            i--;
        }

        public int AddToI(int add)
        {
            i += add;
            return i;
        }

        public void UnrelatedMethod()
        {
            // do something unrelated
        }

        public void AddedThisMethodLater()
        {
            int number = 12;
            i += number;
        }

        public void DecrememntI()
        {
            i--;
        }
    }
}
