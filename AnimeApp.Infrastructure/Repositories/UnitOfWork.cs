using AnimeApp.Domain.Entities;
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
        private IGenericRepository<Category> _categories;
        private IGenericRepository<AnimeShow> _animeShows;
        private IGenericRepository<Cast> _cast;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Category> Categories =>
        _categories ??= new GenericRepository<Category>(_context);

        public IGenericRepository<AnimeShow> AnimeShows =>
            _animeShows ??= new GenericRepository<AnimeShow>(_context);

        public IGenericRepository<Cast> Casts =>
            _cast ??= new GenericRepository<Cast>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
