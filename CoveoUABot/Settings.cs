using System.Configuration;
using System;

namespace CoveoUABot
{
    public static class Settings
    {
        public static string CoveoSearchTerms
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:SearchTerms");
            }
        }
        
        public static string CoveoPushApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:PushApiKey");
            }
        }

        public static string CoveoOrganizationId
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:OrganizationID");
            }
        }

        public static string CoveoProductsSourceId
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:Products:SourceID");
            }
        }

        public static int CoveoIndexingRetryAttempts
        {
            get
            {
                int maxRetries = 3;
                string coveoIndexingRetryAttempts = ConfigurationManager.AppSettings.Get("Coveo:Indexing:Retry");
                if (!string.IsNullOrEmpty(coveoIndexingRetryAttempts))
                {
                    maxRetries = Convert.ToInt32(coveoIndexingRetryAttempts);
                }

                return maxRetries;
            }
        }

        public static int CoveoIndexingThreadSleepTime
        {
            get
            {
                int threadSleepTime = 10;
                string coveoIndexingThreadSleepTime = ConfigurationManager.AppSettings.Get("Coveo:Indexing:ThreadSleep");
                if (!string.IsNullOrEmpty(coveoIndexingThreadSleepTime))
                {
                    threadSleepTime = Convert.ToInt32(coveoIndexingThreadSleepTime);
                }
                return threadSleepTime;
            }
        }

        public static string CoveoDigizuiteCmsSourceId
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:Cms:Documents:SourceID");
            }
        }

        public static string CoveoDigizuiteCommerceSourceId
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:Commerce:Documents:SourceID");
            }
        }

        public static string CoveoNavigationSourceId
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:Navigation:SourceID");
            }
        }

        public static string CoveoProductsSourceName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:Products:SourceName");
            }
        }

        public static string CoveoNavigationSourceName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:Navigation:SourceName");
            }
        }

        public static string CoveoRelatedContentSourceName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:RelatedContent:SourceName");
            }
        }

        public static string CoveoPipeline
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:Pipeline");
            }
        }

        public static string CoveoSearchHub
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Coveo:SearchHub");
            }
        }
    }
}
