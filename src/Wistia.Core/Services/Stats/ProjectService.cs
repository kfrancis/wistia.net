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
    public class ProjectService : WistiaClientBase
    {
        public ProjectService(string apiKey) : base("stats", apiKey)
        {
        }

        public async Task<ProjectStats> Get(int projectId)
        {
            var request = new RestRequest(this.ServiceKey + string.Format("/projects/{0}.json", projectId), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<ProjectStats>(request);
        }

        public async Task<List<ProjectStats>> GetByDate(int projectId)
        {
            var request = new RestRequest(this.ServiceKey + string.Format("/projects/{0}/by_date.json", projectId), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<List<ProjectStats>>(request);
        }
    }
}
