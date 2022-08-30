using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Coveo.Connectors.Utilities.PlatformSdk.Helpers;
using Coveo.Connectors.Utilities.PlatformSdk.Model.Search;
using Coveo.Connectors.Utilities.Runtime;
using CoveoUABot.Coveo;

namespace CoveoUABot
{
    class Program
    {
        private static List<string> SearchTerms = Settings.CoveoSearchTerms.Split(',').ToList();
        static void Main(string[] args)
        {
            Console.WriteLine("Starting UA Bot.....");
            RegisterClient registerClient = new RegisterClient();
            var client = registerClient.RegisterCoveoPlatformClient();

            if (client != null)
            {
                NewSearchServiceManager newSearchServiceManager = new NewSearchServiceManager(client.Config, RequestHelper.GetRequestManager(client.Config), RequestHelper.GetRequestRetryer(client.Config));
                UsageAnalyticsServiceManager analyticsServiceManager = new UsageAnalyticsServiceManager(client.Config, RequestHelper.GetRequestManager(client.Config), RequestHelper.GetRequestRetryer(client.Config));
                foreach (string searchTerm in SearchTerms)
                {
                    var clientId = Guid.NewGuid().ToString();
                    Console.WriteLine("Search query for: {0}", searchTerm);
                    if (SearchTerms.IndexOf(searchTerm) != 0)
                    {
                        Thread.Sleep(1000);
                    }
                    QueryParameters queryParameters = new QueryParameters() { Query = searchTerm, Pipeline = Settings.CoveoPipeline };
                    var results = newSearchServiceManager.Search(queryParameters, CancellationToken.None);
                    if (results != null && !string.IsNullOrEmpty(results.SearchUid))
                    {
                        UsageAnalyticsQueryRequest analyticsQueryRequest = new UsageAnalyticsQueryRequest()
                        {
                            anonymous = false,
                            language = "en",
                            queryPipeline = Settings.CoveoPipeline,
                            actionCause = "searchboxSubmit",
                            queryText = searchTerm,
                            searchQueryUid = results.SearchUid,
                            responseTime = 145,
                            clientId = clientId,
                            originLevel2 = Settings.CoveoPipeline,
                            originLevel1 = Settings.CoveoSearchHub
                        };
                        Console.WriteLine("Analytics Search query for: {0}", searchTerm);
                        analyticsServiceManager.LogUsageAnalytics(analyticsQueryRequest, "search", CancellationToken.None);

                        if (results.Results != null && results.Results.Any())
                        {
                            var firstResult = results.Results.First();
                            var uri = firstResult.Raw.GetValueAsString("uri");
                            var uriHash = firstResult.Raw.GetValueAsString("urihash");
                            var source = firstResult.Raw.GetValueAsString("source");

                            UsageAnalyticsQueryRequest analyticsQueryRequestForClick = new UsageAnalyticsQueryRequest()
                            {
                                anonymous = false,
                                language = "en",
                                queryPipeline = Settings.CoveoPipeline,
                                actionCause = "documentOpen",
                                queryText = searchTerm,
                                searchQueryUid = results.SearchUid,
                                responseTime = 145,
                                clientId = clientId,
                                documentUri = uri,
                                documentUriHash = uriHash,
                                documentPosition = 2,
                                sourceName = source,
                                originLevel2 = Settings.CoveoPipeline,
                                originLevel1 = Settings.CoveoSearchHub
                            };
                            Console.WriteLine("Analytics Click query for: {0}", searchTerm);
                            var analyticsQueryResponse = analyticsServiceManager.LogUsageAnalytics(analyticsQueryRequestForClick, "click", CancellationToken.None);
                        }

                    }
                }
            }
            Console.WriteLine("Process Complete!!");
            //Console.ReadLine();
        }
    }
}
