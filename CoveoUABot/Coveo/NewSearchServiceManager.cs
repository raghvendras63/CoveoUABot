using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Coveo.Connectors.Utilities.PlatformSdk.Auth;
using Coveo.Connectors.Utilities.PlatformSdk.Config;
using Coveo.Connectors.Utilities.PlatformSdk.Manager;
using Coveo.Connectors.Utilities.PlatformSdk.Model;
using Coveo.Connectors.Utilities.PlatformSdk.Model.Search;
using Coveo.Connectors.Utilities.PlatformSdk.Request.Search;
using Coveo.Connectors.Utilities.RestClient.Request;

namespace CoveoUABot.Coveo
{
    public class NewSearchServiceManager : ServiceManagerBase
    {
        /// <summary>
        /// Initializes the <see cref="T:Coveo.Connectors.Utilities.PlatformSdk.Manager.SearchServiceManager" /> class.
        /// </summary>
        /// <param name="config">The Coveo platform configuration.</param>
        /// <param name="requestManager">The HTTP request manager.</param>
        /// <param name="requestRetryer">The HTTP request retryer.</param>
        public NewSearchServiceManager(
            ICoveoPlatformConfig config,
            IHttpRequestManager requestManager,
            IRequestRetryer requestRetryer)
            : base(config, requestManager, requestRetryer)
        {
        }

        /// <summary>Initializes the Permission Service manager.</summary>
        /// <param name="config">The configuration to be used.</param>
        /// <param name="requestManager">The HTTP request manager to be used.</param>
        /// <param name="requestRetryer">The retryer that will execute a request and retries it if it fails.</param>
        /// <param name="authProvider">The authentication provider to authenticate requests.</param>
        public NewSearchServiceManager(
            ICoveoPlatformConfig config,
            IHttpRequestManager requestManager,
            IRequestRetryer requestRetryer,
            IAuthenticationProvider authProvider)
            : base(config, requestManager, requestRetryer, authProvider)
        {
        }

        /// <inheritdoc />
        public NewsearchQueryResponse Search(
            QueryParameters query,
            CancellationToken cancellationToken)
        {
            return this.ExecuteRequest<NewsearchQueryResponse, Error>(new SearchRequest(this.Config, query).Build(), cancellationToken).ResponseObject;
        }
    }
}
