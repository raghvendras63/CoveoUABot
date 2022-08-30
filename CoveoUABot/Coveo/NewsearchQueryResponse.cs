using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coveo.Connectors.Utilities.PlatformSdk.Model.Search;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CoveoUABot.Coveo
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class NewsearchQueryResponse
    {
        public int TotalCount { get; set; }

        /// <summary>The duration (in ms) of the query.</summary>
        public int Duration { get; set; }

        /// <summary>The name of the pipeline used to execute the query.</summary>
        public string Pipeline { get; set; }

        /// <summary>The set of search results.</summary>
        public IEnumerable<SearchResult> Results { get; set; }

        /// <summary>The search execution report.</summary>
        public SearchExecutionReport ExecutionReport { get; set; }

        public string SearchUid { get; set; }
    }
}
