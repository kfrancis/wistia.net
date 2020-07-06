﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PortableRest;
using Wistia.Core.Services.Stats.Models;

namespace Wistia.Core.Services.Stats
{
    public class VisitorService : WistiaClientBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey"></param>
        public VisitorService(string apiKey) : base("stats", apiKey)
        {
        }

        public async Task<List<VisitorStat>> GetBySearchTerm(string term)
        {
            var request = new RestRequest(ServiceKey + string.Format("/visitors.json?search={0}", term), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<List<VisitorStat>>(request);
        }

        public async Task<List<VisitorStatEvent>> GetVisitoryEvents(string visitorKey)
        {
            var request = new RestRequest(ServiceKey + string.Format("/events.json?visitor_key={0}", visitorKey), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<List<VisitorStatEvent>>(request);
        }

        public async Task<VisitorStatEventDetail> GetVisitoryEventDetails(string eventKey)
        {
            var request = new RestRequest(ServiceKey + string.Format("/events/{0}.json", eventKey), HttpMethod.Get) { ContentType = ContentTypes.Json };
            var authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("api:{0}", ApiKey)));
            request.Headers.Add("Authorization", "Basic " + authInfo);
            return await ExecuteAsync<VisitorStatEventDetail>(request);
        }
    }
}
