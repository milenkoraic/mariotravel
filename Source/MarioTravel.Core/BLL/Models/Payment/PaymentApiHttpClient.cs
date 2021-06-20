using EnsureThat;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarioTravel.Core.BLL.Models.Payment
{
    public class PaymentApiHttpClient
    {
        private readonly HttpClient client;

        public PaymentApiHttpClient(HttpClient client)
        {
            this.client = EnsureArg.IsNotNull(client, nameof(client));
        }

        public async Task SendAsync(HttpRequestMessage msg)
        {
            var rsp = await client.SendAsync(msg);
            rsp.EnsureSuccessStatusCode();
        }
    }
}