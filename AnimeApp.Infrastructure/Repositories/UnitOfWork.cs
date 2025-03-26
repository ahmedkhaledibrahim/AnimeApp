using AnimeApp.Domain.Entities;
using AnimeApp.Domain.Entities.Common;
using AnimeApp.Domain.Interfaces;
using AnimeApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            GenericRepository<T> repository = new GenericRepository<T>(_context);
            return repository;
        }
    }
}
