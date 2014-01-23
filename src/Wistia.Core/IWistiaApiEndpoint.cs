using System.Collections.Generic;
using System.Threading.Tasks;
using Wistia.Core.Models;

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

    public interface IWistiaApiScopedEndpoint<T> where T : class
    {
        Task<List<T>> All(string parentId);

        Task<T> GetById(string parentId, string childId);

        Task<T> Create(string parentId, T item);

        Task Update(string parentId, T item);

        Task Delete(string parentId, string childId);
    }
}