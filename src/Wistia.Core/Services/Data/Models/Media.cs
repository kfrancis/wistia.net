#region License, Terms and Conditions
//
// Media.cs
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

namespace Wistia.Core.Services.Data.Models
{
    public class Media
    {
        public DateTime created { get; set; }
        public string description { get; set; }
        public double duration { get; set; }
        public string hashed_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public double progress { get; set; }
        public string status { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string type { get; set; }
        public DateTime updated { get; set; }
        public List<Asset> assets { get; set; }
    }
}
