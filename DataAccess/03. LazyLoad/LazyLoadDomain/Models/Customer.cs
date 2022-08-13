using System;


namespace LazyLoadDomain.Models
{
    public class Customer
    {
        // mark properties as virtual to use Virtual Proxy pattern
        // (same for Ghost Object)
        public Guid CustomerId { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShippingAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual byte[] ProfilePicture { get; set; }

        // for non-proxy(Virtual Proxy pattern) solutions
        //public Guid CustomerId { get; set; }
        //public string Name { get; set; }
        //public string ShippingAddress { get; set; }
        //public string City { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }

        // Lazy Initialization
        // this one is actually bad implementation since Customer entity
        // should know about particular source of image
        //private byte[] profilePicture;
        //public byte[] ProfilePicture
        //{
        //    get => profilePicture ??= ProfilePictureService.GetFor(Name);

        //    set => profilePicture = value;
        //}

        // NTS Lazy Initialization + Value Holder pattern
        //public IValueHolder<byte[]> ProfilePictureValueHolder { get; set; }
        //public byte[] ProfilePicture => ProfilePictureValueHolder.GetValue(Name);

        // ThreadSafe Lazy Initialization + Value Holder pattern
        //public Lazy<byte[]> ProfilePictureValueHolder { get; set; }
        //public byte[] ProfilePicture => ProfilePictureValueHolder.Value;


        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
