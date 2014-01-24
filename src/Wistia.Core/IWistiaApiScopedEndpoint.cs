using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wistia.Core
{
    public interface IWistiaApiScopedEndpoint<T> where T : class
    {
        Task<List<T>> All(string parentId);

        Task<T> GetById(string parentId, string childId);

        Task<T> Create(string parentId, T item);

        Task Update(string parentId, T item);

        Task Delete(string parentId, string childId);
    }
}