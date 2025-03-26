using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
