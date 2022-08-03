using System;


namespace BridgeInheritance.Models
{
    public class MilitaryDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 10;
        }
    }
}
