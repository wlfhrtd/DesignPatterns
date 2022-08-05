using SpecificationConstraints.Interfaces;


namespace SpecificationConstraints.Models
{
    public class PhoneNumber : IContactInfo
    {
        public int CountryCode { get; internal set; }

        public int AreaCode { get; internal set; }

        public int Number { get; internal set; }

        internal PhoneNumber()
        { }

        public override int GetHashCode() =>
            CountryCode.GetHashCode() ^
            AreaCode.GetHashCode() ^
            Number.GetHashCode();

        public override bool Equals(object obj)
        {
            PhoneNumber other = obj as PhoneNumber;
            return
                other != null
                && other.CountryCode == CountryCode
                && other.AreaCode == AreaCode
                && other.Number == Number;
        }

        public override string ToString() => $"+{CountryCode}({AreaCode}){Number}";
    }
}
