namespace Facade.Models
{
    public class State
    {
        public State GetStateForZipCode(string zipCode)
        {
            return new State();
        }

        public string Name => "Washington";
    }
}
