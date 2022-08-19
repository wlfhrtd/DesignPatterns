using Adapter.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Adapter._05._DependencyInjection
{
    public class StarWarsApi
    {
        public async Task<List<Person>> GetCharacters()
        {
            using (var client = new HttpClient())
            {
                string url = "https://swapi.dev/api/people";
                string result = await client.GetStringAsync(url);
                var people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;

                return people;
            }
        }
    }
}
