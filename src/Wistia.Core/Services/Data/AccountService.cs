using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PortableRest;
using Wistia.Core.Services.Data.Models;

namespace Wistia.Core.Services.Data
{
    public class AccountService : WistiaClientBase
    {
        public AccountService(string apiKey) : base(apiKey)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Account> Get()
        {
            var request = new RestRequest("account.json", HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<Account>(request);
        }
    }
}
