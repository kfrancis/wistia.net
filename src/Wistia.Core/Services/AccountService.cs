using System.Net.Http;
using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wistia.Core.Models;

namespace Wistia.Core.Services
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
