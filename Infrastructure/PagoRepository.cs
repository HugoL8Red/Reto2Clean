using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Reto2.Domain.Entities;
using Reto2.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto2.Infrastructure
{
    public class PagoRepository : IPagoRepository
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<int> RealizarPago(Pago pago)
        {
            // Serialize the object to a JSON string
            string jsonContent = JsonConvert.SerializeObject(pago);

            // Wrap the JSON string in StringContent
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Define the API endpoint URI
            var uri = new Uri("http://localhost:5001/api/pago"); // A fake API for testing

            try
            {
                Console.WriteLine("Realizar Pago");
                // Send the POST request as an asynchronous operation
                HttpResponseMessage response = await client.PostAsync(uri, content);

                // Ensure the response indicates success (status codes 200-299)
                response.EnsureSuccessStatusCode();

                // Read the response body as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Request successful!");
                Console.WriteLine("Response body: " + responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return -1;
            }
            return 1;
        }
    }
}
