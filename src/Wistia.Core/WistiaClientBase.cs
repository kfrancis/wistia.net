#region License, Terms and Conditions

//
// WistiaClientBase.cs
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
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PortableRest;

namespace Wistia.Core
{
    /// <summary>
    /// The base for all Wistia REST Clients in this library.
    /// </summary>
    public abstract class WistiaClientBase : RestClient
    {
        #region Properties
        /// <summary>
        /// This value allows the derivative classes to set the url segment that immediately follows the base url:
        /// https://api.wistia.com/ + v1 + / (data API url segement)
        /// https://api.wistia.com/ + v1 + /stats (stats API url segment)
        /// </summary>
        public string ServiceKey { get; private set; }

        /// <summary>
        /// The api key credential that allows remote API access
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// The version of the API to access. This version is typically embedded into the URL of the request, 
        /// although occasionally you can specify it in the header. We support both options.
        /// </summary>
        /// <remarks>
        /// You can change the logic on the getter to automatically update the BaseUrl if the ApiVersion changes.
        /// </remarks>
        public string ApiVersion { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">The api key to authorize access to the service</param>
        /// <param name="apiVersion">The api version key (ie. v1, v2)</param>
        /// <param name="serviceKey">The url segment that indicates the API service (data, stats, etc)</param>
        public WistiaClientBase(string apiKey, string apiVersion, string serviceKey)
        {
            this.ServiceKey = serviceKey;
            this.ApiKey = apiKey;
            this.ApiVersion = apiVersion;

            // PCL-friendly way to get current version
            var thisAssembly = typeof(Wistia.Core.WistiaDataClient).Assembly;
            var thisAssemblyName = new AssemblyName(thisAssembly.FullName);
            var thisVersion = thisAssemblyName.Version;

            var portableRestAssembly = typeof(RestRequest).Assembly;
            var portableRestAssemblyName = new AssemblyName(portableRestAssembly.FullName);
            var portableRestVersion = portableRestAssemblyName.Version;

            UserAgent = string.Format("Wistia {0} Client for .NET {1} (PortableRest {2})", ApiVersion, thisVersion, portableRestVersion);

            BaseUrl = "https://api.wistia.com/" + ApiVersion;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceKey">The url segment that indicates the API service (data, stats, etc)</param>
        /// <param name="apiKey">The api key to authorize access to the service</param>
        public WistiaClientBase(string serviceKey, string apiKey) : this(apiKey, "v1", serviceKey)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">The api key to authorize access to the service</param>
        public WistiaClientBase(string apiKey) : this(apiKey, "v1", string.Empty)
        {
        }
        #endregion

        #region Request Methods
        protected Task DeleteRequest(string path, params object[] args)
        {
            // TODO: Implement this method, as soon as PortableRest releases PUT/PUT/DELETE support
            throw new NotImplementedException();
        }

        protected Task PutRequest<T, T1>(T item, string path, params object[] args)
        {
            // TODO: Implement this method, as soon as PortableRest releases PUT/PUT/DELETE support
            throw new NotImplementedException();
        }

        protected Task<T> PostRequest<T, T1>(T item, string path)
        {
            // TODO: Implement this method, as soon as PortableRest releases PUT/PUT/DELETE support
            throw new NotImplementedException();
        }

        protected async Task<T> GetRequest<T>(string path, params object[] args) where T : class
        {
            var request = new RestRequest(string.Format(path, args), HttpMethod.Get) { ContentType = ContentTypes.Json };
            SetAuthorization(request);
            return await ExecuteAsync<T>(request);
        }
        #endregion

        #region Helper Methods
        protected void SetAuthorization(RestRequest request)
        {
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
        }
        #endregion
    }
}
