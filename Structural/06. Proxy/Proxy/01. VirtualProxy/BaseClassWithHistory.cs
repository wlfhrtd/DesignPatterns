using System.Collections.Generic;

namespace Proxy._01._VirtualProxy
{
    public abstract class BaseClassWithHistory
    {
        public List<string> History { get; } = new List<string>();
    }
}
