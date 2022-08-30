using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveoUABot.Coveo
{
    public class UsageAnalyticsQueryResponse
    {
        public string searchEventUid { get; set; }
        public string visitId { get; set; }
        public string visitorId { get; set; }
        public string clientId { get; set; }
    }
}
