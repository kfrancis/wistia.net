using System.Net.Http;
using System.Threading.Tasks;
using PortableRest;
using Wistia.Core.Data;

namespace Wistia.Core
{
    public interface IWistiaDataClient
    {
        Task<Account> GetAccount();
    }
}