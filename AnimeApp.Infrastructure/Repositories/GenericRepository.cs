using AnimeApp.Domain.Interfaces;
using AnimeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entitySet = await _dbSet.FindAsync(id);
            _dbSet.Remove(entitySet);
            await Task.CompletedTask;
        }

        public async Task<T> GetByPropertyValueAsync(string propertyName, string value)
        {
            // Create a parameter for the entity type
            var parameter = Expression.Parameter(typeof(T), "entity");

            // Create a property expression (entity.PropertyName)
            var property = Expression.Property(parameter, propertyName);

            // Create a constant for the value to compare
            var constant = Expression.Constant(value);

            // Create an equality expression (entity.PropertyName == value)
            var equality = Expression.Equal(property, constant);

            // Create a lambda expression (entity => entity.PropertyName == value)
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            // Use the lambda in LINQ's Where method
            return await _dbSet.FirstOrDefaultAsync(lambda);
        }
    
    }
}
