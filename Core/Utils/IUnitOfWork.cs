using Core.Abstracts.Bases;
using Core.Concretes.Models;

namespace Core.Utils
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        Task<Reply> CommitAsync();
    }
}
