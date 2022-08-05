using SpecificationBuilding.Interfaces;

namespace SpecificationBuilding.Models
{
    public class MacAddress : IUserIdentity
    {
        public string NicPart { get; set; }
    }
}