#region License, Terms and Conditions

//
// ProjectService.cs
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
    /// <summary>
    /// Project stats
    /// </summary>
    public class ProjectService : WistiaClientBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">The api key credential</param>
        public ProjectService(string apiKey) : base("stats", apiKey)
        {
        }

        /// <summary>
        /// Get the statistics for a project
        /// </summary>
        /// <param name="projectId">The id of the project (non-hashed)</param>
        /// <returns>The project stats</returns>
        public async Task<ProjectStats> Get(int projectId)
        {
            var request = new RestRequest(this.ServiceKey + string.Format("/projects/{0}.json", projectId), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<ProjectStats>(request);
        }

        /// <summary>
        /// Get the statistics for a project by date
        /// </summary>
        /// <param name="projectId">The id of the project (non-hashed)</param>
        /// <returns>The list of project stats ordered by date</returns>
        public async Task<List<ProjectStats>> GetByDate(int projectId)
        {
            var request = new RestRequest(this.ServiceKey + string.Format("/projects/{0}/by_date.json", projectId), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<List<ProjectStats>>(request);
        }
    }
}
