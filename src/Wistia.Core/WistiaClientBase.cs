using System;
using System.Linq;
using System.Reflection;
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

using PortableRest;

namespace Wistia.Core
{
    /// <summary>
    /// The base for all Wistia REST Clients in this library. Handles setting the UserAgent.
    /// </summary>
    public abstract class WistiaClientBase : RestClient
    {
        #region Properties
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
        public WistiaClientBase(string apiKey, string apiVersion)
        {
            this.ApiKey = apiKey;
            this.ApiVersion = apiVersion;

            // PCL-friendly way to get current version
            var thisAssembly = typeof(Wistia.Core.WistiaDataClient).Assembly;
            var thisAssemblyName = new AssemblyName(thisAssembly.FullName);
            var thisVersion = thisAssemblyName.Version;

            var prAssembly = typeof(RestRequest).Assembly;
            var prAssemblyName = new AssemblyName(prAssembly.FullName);
            var prVersion = prAssemblyName.Version;

            UserAgent = string.Format("Wistia {0} Client for .NET {1} (PortableRest {2})", ApiVersion, thisVersion, prVersion);

            BaseUrl = "https://api.wistia.com/" + ApiVersion;
        }

        public WistiaClientBase(string apiKey)
            :this(apiKey, "v1")
        {
        }
        #endregion
    }
}
