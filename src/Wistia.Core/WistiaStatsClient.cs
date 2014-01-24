using System;
using System.Linq;
using System.Threading.Tasks;
using Wistia.Core.Services.Stats;

namespace Wistia.Core
{
    public class WistiaStatsClient
    {
        public WistiaStatsClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(apiKey);

            this.Account = new AccountService(apiKey);
            this.Projects = new ProjectService(apiKey);
        }
        public AccountService Account { get; private set; }
        public ProjectService Projects { get; private set; }
    }
}
