namespace SpecificationBuilding.Models
{
    public class Producer
    {
        public string Name { get; internal set; }

        public override string ToString() => Name;
    }
}