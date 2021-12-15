using Database.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.GenericRep
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _entities;

        public GenericRepository(IGenericDbClient<TEntity> genericDbClient)
        {
            _entities = genericDbClient.GetEntitiesCollection();
        }
        public TEntity Create(TEntity entity)
        {
            _entities.InsertOne(entity);
            return entity;
        }

        public TEntity Get(string id)
        {
            return _entities.Find(e => e)
        }

        public List<TEntity> Gets()
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity book)
        {
            throw new NotImplementedException();
        }
    }
}
