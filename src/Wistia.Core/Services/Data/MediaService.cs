#region License, Terms and Conditions

//
// MediaService.cs
//
// Author: Kori Francis <twitter.com/djbyter>
// Copyright (C) 2014 Kori Francis. All rights reserved.
// 
// THIS FILE IS LICENSED UNDER THE MIT LICENSE AS OUTLINED IMMEDIATELY BELOW:
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using Wistia.Core.Services.Data.Models;

namespace Wistia.Core.Services.Data
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
