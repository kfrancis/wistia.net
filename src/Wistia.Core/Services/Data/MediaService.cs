using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wistia.Core.Services.Data.Models;

namespace Wistia.Core.Services.Data.Services
{
    public class MediaService : WistiaClientBase, IWistiaApiEndpoint<Media>
    {
        public MediaService(string apiKey) : base(apiKey)
        {
        }

        public async Task<List<Media>> All()
        {
            return await GetRequest<List<Media>>("medias.json");
        }

        public async Task<Media> GetById(string id)
        {
            return await GetRequest<Media>("medias/{0}.json", id);
        }

        public async Task<Media> Create(Media item)
        {
            return await PostRequest<Media, Media>(item, "medias.json");
        }

        public async Task Update(Media item)
        {
            await PutRequest<Media, Media>(item, "medias/{0}.json", item.hashed_id);
        }

        public async Task Delete(string id)
        {
            await DeleteRequest("/medias/{0}", id);
        }
    }
}
