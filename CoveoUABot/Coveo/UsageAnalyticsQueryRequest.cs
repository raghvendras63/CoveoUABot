using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveoUABot.Coveo
{
    public class UsageAnalyticsQueryRequest
    {
        public string language { get; set; }
        public string userAgent { get; set; }
        public CustomData customData { get; set; }
        public bool anonymous { get; set; }
        public string username { get; set; }
        public string userDisplayName { get; set; }
        public string splitTestRunName { get; set; }
        public string splitTestRunVersion { get; set; }
        public string originLevel1 { get; set; }
        public string originLevel2 { get; set; }
        public string originLevel3 { get; set; }
        public int outcome { get; set; }
        public string originContext { get; set; }
        public string clientId { get; set; }
        public string searchQueryUid { get; set; }
        public string queryText { get; set; }
        public string actionCause { get; set; }
        public string advancedQuery { get; set; }
        public int numberOfResults { get; set; }
        public bool contextual { get; set; }
        public int responseTime { get; set; }
        public List<Result> results { get; set; }
        public string queryPipeline { get; set; }
        public List<string> userGroups { get; set; }
        public string indexId { get; set; }
        public List<FacetState> facetState { get; set; }
        public int documentPosition { get; set; }
        public string documentUri { get; set; }
        public string documentUriHash { get; set; }
        public string sourceName { get; set; }
    }

    public class CustomData
    {
        public Property1 property1 { get; set; }
        public Property2 property2 { get; set; }
    }

    public class FacetState
    {
        public string field { get; set; }
        public string id { get; set; }
        public string value { get; set; }
        public int valuePosition { get; set; }
        public string displayValue { get; set; }
        public string facetType { get; set; }
        public string state { get; set; }
        public int facetPosition { get; set; }
        public string title { get; set; }
    }

    public class Property1
    {
    }

    public class Property2
    {
    }

    public class Result
    {
        public string documentUri { get; set; }
        public string documentUriHash { get; set; }
    }

}
