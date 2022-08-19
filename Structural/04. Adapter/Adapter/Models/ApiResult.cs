using System.Collections.Generic;

namespace Adapter.Models
{
    public class ApiResult<T>
    {
        public int Count { get; set; }

        public List<T> Results { get; set; }
    }
}
