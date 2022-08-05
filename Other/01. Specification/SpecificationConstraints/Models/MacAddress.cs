using SpecificationConstraints.Interfaces;


namespace SpecificationConstraints.Models
{
    public class MacAddress : IUserIdentity
    {
        public string NicPart { get; set; }
    }
}
