#region License, Terms and Conditions
//
// Asset.cs
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

namespace Wistia.Core.Services.Data.Models
{
    /// <summary>
    /// Asset
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// The asset url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// The pixel width of the asset
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// The pixel height of the asset
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// The file size (in bytes) of the asset
        /// </summary>
        public long fileSize { get; set; }
        /// <summary>
        /// The type of content
        /// </summary>
        public string contentType { get; set; }
        /// <summary>
        /// The asset type
        /// </summary>
        public string type { get; set; }
    }
}
