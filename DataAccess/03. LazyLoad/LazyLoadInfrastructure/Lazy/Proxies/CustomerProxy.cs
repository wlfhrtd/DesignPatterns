using LazyLoadDomain.Models;
using LazyLoadInfrastructure.Services;

namespace LazyLoadInfrastructure.Lazy.Proxies
{
    public class CustomerProxy : Customer
    {
        // Lazy Init + Virtual Proxy pattern
        public override byte[] ProfilePicture
            => base.ProfilePicture ??= ProfilePictureService.GetFor(Name);
    }
}
