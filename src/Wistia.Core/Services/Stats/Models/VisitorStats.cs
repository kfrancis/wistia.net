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
using Newtonsoft.Json;

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
    

    public partial class Org
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class VisitorIdentity
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("org")]
        public Org Org { get; set; }
    }

    public partial class UserAgentDetails
    {

        [JsonProperty("browser")]
        public string Browser { get; set; }

        [JsonProperty("browser_version")]
        public string BrowserVersion { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("mobile")]
        public bool Mobile { get; set; }
    }

    public partial class VisitorStat
    {

        [JsonProperty("visitor_key")]
        public string VisitorKey { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("last_active_at")]
        public DateTime LastActiveAt { get; set; }

        [JsonProperty("last_event_key")]
        public string LastEventKey { get; set; }

        [JsonProperty("load_count")]
        public int LoadCount { get; set; }

        [JsonProperty("play_count")]
        public int PlayCount { get; set; }

        [JsonProperty("identifying_event_key")]
        public string IdentifyingEventKey { get; set; }

        [JsonProperty("visitor_identity")]
        public VisitorIdentity VisitorIdentity { get; set; }

        [JsonProperty("user_agent_details")]
        public UserAgentDetails UserAgentDetails { get; set; }

        public string viewing_url => $"https://myrenatus.wistia.com/stats/viewer/{VisitorKey}";
    }

    public partial class ConversionData
    {

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }

    public partial class Thumbnail
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("fileSize")]
        public int FileSize { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class VisitorStatEvent
    {

        [JsonProperty("received_at")]
        public DateTime ReceivedAt { get; set; }

        [JsonProperty("event_key")]
        public string EventKey { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("percent_viewed")]
        public double PercentViewed { get; set; }

        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        [JsonProperty("conversion_type")]
        public string ConversionType { get; set; }

        [JsonProperty("conversion_data")]
        public ConversionData ConversionData { get; set; }

        [JsonProperty("iframe_heatmap_url")]
        public string IframeHeatmapUrl { get; set; }

        [JsonProperty("visitor_key")]
        public string VisitorKey { get; set; }

        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("media_name")]
        public string MediaName { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        public VisitorStatEventDetail Detail { get; set; }
    }

    public partial class VisitorStatEventDetail
    {

        [JsonProperty("received_at")]
        public DateTime ReceivedAt { get; set; }

        [JsonProperty("event_key")]
        public string EventKey { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("percent_viewed")]
        public double PercentViewed { get; set; }

        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        [JsonProperty("conversion_type")]
        public string ConversionType { get; set; }

        [JsonProperty("conversion_data")]
        public ConversionData ConversionData { get; set; }

        [JsonProperty("iframe_heatmap_url")]
        public string IframeHeatmapUrl { get; set; }

        [JsonProperty("visitor_key")]
        public string VisitorKey { get; set; }

        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("media_name")]
        public string MediaName { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }
    }
}
