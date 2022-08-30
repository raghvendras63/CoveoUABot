using Coveo.Connectors.Utilities.PlatformSdk.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Coveo.Connectors.Utilities.Contracts;
using Coveo.Connectors.Utilities.PlatformSdk.Config;
using Coveo.Connectors.Utilities.PlatformSdk.Model;
using Coveo.Connectors.Utilities.PlatformSdk.Model.Search;
using Coveo.Connectors.Utilities.PlatformSdk.Request.Search;
using Coveo.Connectors.Utilities.RestClient.Request;

namespace CoveoUABot.Coveo
{
    public class UsageAnalyticsRequest : BaseRequest, IRestRequestBuilder
    {
        private readonly UsageAnalyticsQueryRequest _query;
        private readonly string _type;

        /// <summary>Constructor.</summary>
        /// <param name="config">The platform configuration.</param>
        /// <param name="query">The query expression.</param>
        public UsageAnalyticsRequest(ICoveoPlatformConfig config, UsageAnalyticsQueryRequest query, string type)
            : base(config)
        {
            this._query = query;
            _type = type;
        }

        /// <inheritdoc />
        public IRestRequest Build()
        {
            IRestRequest request = new RestRequest("https://analytics.cloud.coveo.com/", string.Format("rest/ua/v15/analytics/{0}", _type)).AddParameter("organizationId", this.Config.OrganizationId).AddJsonPayloadContent(this.SerializeRequestBody((object)this._query)).SetMethod(HttpMethod.Post);
            return request;
        }

    }
}

