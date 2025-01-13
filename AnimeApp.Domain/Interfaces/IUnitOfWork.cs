using AnimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<AnimeShow> AnimeShows { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Cast> Casts { get; }
        Task<int> SaveChangesAsync();
    }
}
