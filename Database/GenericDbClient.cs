using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class GenericDbClient<TEntity> : IGenericDbClient<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _entities;
        public GenericDbClient(IOptions<BookstoredDbConfig> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
            _entities = database.GetCollection<TEntity>(bookstoreDbConfig.Value.Books_Collection_Name);
        }
        public IMongoCollection<TEntity> GetEntitiesCollection()
        {
            return _entities;
        }

    }
}
