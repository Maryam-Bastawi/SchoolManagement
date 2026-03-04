
using SchoolManagement.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Interface
{
   public interface IUnitOfWork
{
    Task<int> CompleteAsync();
    IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>()
        where TEntity : class;
}
}
