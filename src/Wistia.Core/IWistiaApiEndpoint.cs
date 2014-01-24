using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wistia.Core
{
    public interface IWistiaApiEndpoint<T> where T : class
    {
        Task<List<T>> All();

        Task<T> GetById(string id);

        Task<T> Create(T project);

        Task Update(T project);

        Task Delete(string id);
    }
}