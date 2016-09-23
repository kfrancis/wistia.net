#region License, Terms and Conditions

//
// SharingService.cs
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
