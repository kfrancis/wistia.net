using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PortableRest;
using Wistia.Core.Services.Stats.Models;

namespace Wistia.Core.Services.Stats
{
    public class MediaService : WistiaClientBase
    {
        public MediaService(string apiKey) : base("stats", apiKey)
        {
        }

        public async Task<MediaStats> Get(int mediaId)
        {
            var request = new RestRequest(this.ServiceKey + string.Format("/medias/{0}.json", mediaId), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<MediaStats>(request);
        }

        public async Task<List<MediaStats>> GetByDate(int mediaId)
        {
            var request = new RestRequest(this.ServiceKey + string.Format("/medias/{0}/by_date.json", mediaId), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<List<MediaStats>>(request);
        }
    }
}
