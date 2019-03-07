using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_back_produktevaluering.web.Repositories
{
    public interface IRepository<T>
    {
        Task<IList<T>> ReadAll();
        Task<T> ReadById(int id);
        Task Create(T model);
        Task Update(T model);
        Task Delete(int id);
    }
}