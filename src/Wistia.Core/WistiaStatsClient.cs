#region License, Terms and Conditions

//
// WistiaStatsClient.cs
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
using Wistia.Core.Services.Stats;

namespace Wistia.Core
{
    /// <summary>
    /// Ever looked at your Wistia heatmaps and wished you could show them to other people with ease? 
    /// Ever looked at your Wistia heatmaps and wished that they were built out of purple cats instead of red, yellow, and green bars?
    /// Want to figure out which of your Wistia videos your users have already viewed and recommend them ones they haven't so they don't get bored?
    /// Want to make sure you purposely recommend the same videos repeatedly until they're annoyed enough to convert?
    /// http://wistia.com/doc/stats-api#stats_api
    /// </summary>
    public sealed class WistiaStatsClient
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">The api key credential</param>
        public WistiaStatsClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(apiKey);

            Account = new AccountService(apiKey);
            Projects = new ProjectService(apiKey);
            Media = new MediaService(apiKey);
        }
        #endregion

        #region Properties
        /// <summary>
        /// An account contains many projects
        /// </summary>
        public AccountService Account { get; private set; }
        /// <summary>
        /// Projects are the main organizational objects within Wistia. Media must be stored within Projects.
        /// </summary>
        public ProjectService Projects { get; private set; }
        /// <summary>
        /// Media are the organizational objects that represent each video within a project.
        /// </summary>
        public MediaService Media { get; private set; }
        #endregion
    }
}
