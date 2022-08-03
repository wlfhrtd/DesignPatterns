using System;


namespace BridgeInheritance.Models
{
    public class NoDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 0;
        }
    }
}
