using System;
using System.Threading.Tasks;

using CRUD.API.Core.Repositories;

namespace CRUD.API.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get;}
        Task<bool> Complete();
    }
}
