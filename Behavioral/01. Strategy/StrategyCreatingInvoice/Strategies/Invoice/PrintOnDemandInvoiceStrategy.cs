using Newtonsoft.Json;
using StrategyCreatingInvoice.Models;
using System;
using System.Net.Http;


namespace StrategyCreatingInvoice.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (HttpClient httpClient = new())
            {
                var content = JsonConvert.SerializeObject(order);
                httpClient.BaseAddress = new Uri("https://print_service.com");
                HttpRequestMessage request = new(
                    HttpMethod.Post,
                    "/print_on_demand");
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                httpClient.SendAsync(request);
            }
        }
    }
}
