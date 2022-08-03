using System;


namespace BridgeInheritance.Models
{
    public class SeniorDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 20;
        }
    }
}
