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
using System.Net.Http;
using System.Threading.Tasks;
using PortableRest;
using Wistia.Core.Services.Stats.Models;

namespace Wistia.Core.Services.Stats
{
    /// <summary>
    /// Media stats
    /// </summary>
    public class MediaService : WistiaClientBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">The api key credential</param>
        public MediaService(string apiKey) : base("stats", apiKey)
        {
        }

        /// <summary>
        /// Get the statistics for a single piece of media
        /// </summary>
        /// <param name="mediaId">The id of the media object</param>
        /// <returns>The media stats</returns>
        public async Task<MediaStats> Get(int mediaId)
        {
            var request = new RestRequest(ServiceKey + $"/medias/{mediaId}.json", HttpMethod.Get) { ContentType = ContentTypes.Json };
            SetAuthorization(request);
            return await ExecuteAsync<MediaStats>(request);
        }

        /// <summary>
        /// Get the statistics for a single piece of media by date
        /// </summary>
        /// <param name="mediaId">The id of the media object</param>
        /// <returns>The list of media stats ordered by date</returns>
        public async Task<List<MediaStats>> GetByDate(int mediaId)
        {
            var request = new RestRequest(ServiceKey + $"/medias/{mediaId}/by_date.json", HttpMethod.Get) { ContentType = ContentTypes.Json };
            SetAuthorization(request);
            return await ExecuteAsync<List<MediaStats>>(request);
        }
    }
}
