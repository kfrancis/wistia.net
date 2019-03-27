#region License, Terms and Conditions

//
// ProjectStats.cs
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
using System.Reflection;

namespace Wistia.Core.Services.Stats.Models
{
    public class VisitorStats
    {
        public string visitor_key { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_active_at { get; set; }
        public string last_event_key { get; set; }
        public int load_count { get; set; }
        public int play_count { get; set; }
        public string identifying_event_key { get; set; }
        public VisitorIdentityStats visitor_identity { get; set; }
        public VisitorUserAgentStats user_agent_details { get; set; }
        public string viewing_url => $"https://myrenatus.wistia.com/stats/viewer/{visitor_key}";
    }

    public class VisitorIdentityStats
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class VisitorUserAgentStats
    {
        public string browser { get; set; }
        public string browser_version { get; set; }
        public string platform { get; set; }
        public bool mobile { get; set; }
    }
}
