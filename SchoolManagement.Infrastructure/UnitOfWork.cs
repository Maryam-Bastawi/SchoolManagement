using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.Interface;
using SchoolManagement.Infrastructure.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<string, object> _repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>()
            where TEntity : class
        {
            var key = $"{typeof(TEntity).Name}_{typeof(TKey).Name}";

            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<TEntity, TKey>(_context);
                _repositories.Add(key, repository);
            }

            return (IGenericRepository<TEntity, TKey>)_repositories[key];
        }
    }
}