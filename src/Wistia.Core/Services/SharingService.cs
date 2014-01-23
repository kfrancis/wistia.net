using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wistia.Core.Models;
using System.Threading.Tasks;

namespace Wistia.Core
{
    public class SharingService : WistiaClientBase, IWistiaApiScopedEndpoint<Sharing>
    {
        public SharingService(string apiKey) : base(apiKey)
        {
        }

        public async Task<List<Sharing>> All(string parentId)
        {
            return await GetRequest<List<Sharing>>("projects/{0}/sharings.json", parentId);
        }

        public async Task<Sharing> GetById(string parentId, string childId)
        {
            return await GetRequest<Sharing>("projects/{0}/sharings/{1}.json", parentId, childId);
        }

        public async Task<Sharing> Create(string parentId, Sharing item)
        {
            return await PostRequest<Sharing, Sharing>(item, "projects/{0}/sharings.json");
        }

        public async Task Update(string parentId, Sharing item)
        {
            await PutRequest<Sharing, Sharing>(item, "projects/{0}/sharings/{1}.json", parentId, item.id.ToString());
        }

        public async Task Delete(string parentId, string childId)
        {
            await DeleteRequest("/projects/{0}/sharings/{1}.json", parentId, childId);
        }
    }
}
