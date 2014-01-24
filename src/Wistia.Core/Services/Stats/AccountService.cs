using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PortableRest;
using Wistia.Core.Services.Stats.Models;

namespace Wistia.Core.Services.Stats
{
    public class AccountService : WistiaClientBase
    {
        public AccountService(string apiKey) : base("stats", apiKey)
        {
        }

        public async Task<AccountStats> Get()
        {
            var request = new RestRequest(this.ServiceKey + "/account.json", HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<AccountStats>(request);
        }
    }
}
