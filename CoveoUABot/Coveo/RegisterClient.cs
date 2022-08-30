using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Coveo.Connectors.Utilities.PlatformSdk;
using Coveo.Connectors.Utilities.PlatformSdk.Config;

namespace CoveoUABot.Coveo
{
    public class RegisterClient
    {
        public ICoveoPlatformClient RegisterCoveoPlatformClient()
        {
            ICoveoPlatformConfig config = new CoveoPlatformConfig(Settings.CoveoPushApiKey, Settings.CoveoOrganizationId);
            ICoveoPlatformClient client = new CoveoPlatformClient(config);
            return client;
        }
    }
}
