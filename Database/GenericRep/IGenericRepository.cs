using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        List<TEntity> Gets();
        TEntity Create(TEntity entity);
        TEntity Get(string id);
        void Remove(string id);
        TEntity Update(TEntity book);
    }
}
