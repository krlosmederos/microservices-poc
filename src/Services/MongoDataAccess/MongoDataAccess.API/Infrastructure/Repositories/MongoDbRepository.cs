using MongoDataAccess.API.Settings;
using MongoDataAccess.API.Models;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;

namespace MongoDataAccess.API.Infrastructure.Repositories
{
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : BaseEntity
    {
        protected IMongoCollection<T> _collection;
        protected IMongoDatabase _database;

        public IMongoCollection<T> Collection
        {
            get
            {
                return _collection;
            }
        }

        public IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }

        #region Constructors
        public MongoDbRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.Database);
            _collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public MongoDbRepository(string connectionString)
        {
            _ = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            var client = new MongoClient(connectionString);
            var databaseName = new MongoUrl(connectionString).DatabaseName;
            _database = client.GetDatabase(databaseName);
            _collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public MongoDbRepository(IMongoDatabase database)
        {
            _ = database ?? throw new ArgumentNullException(nameof(database));
            _database = database;
            _collection = _database.GetCollection<T>(typeof(T).Name);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all entities 
        /// </summary>
        /// <returns>Mongo Queryable of entities</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _collection.Find(t => true).ToEnumerable();
        }

        /// <summary>
        /// Get entity by identifier 
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(string id)
        {
            return _collection.Find(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get entity by identifier async
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        public virtual T Insert(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        /// <summary>
        /// Insert entity async
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        public virtual async Task<T> InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Entities</returns>
        public virtual IEnumerable<T> Insert(IEnumerable<T> entities)
        {
            _collection.InsertMany(entities);
            return entities;
        }

        /// <summary>
        /// Insert entities async
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Entities</returns>
        public virtual async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
            return entities;
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity</returns>
        public virtual T Update(T entity)
        {
            _collection.ReplaceOne(t => t.Id == entity.Id, entity, new ReplaceOptions(){ IsUpsert = false });
            return entity;
        }

        /// <summary>
        /// Update entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity</returns>
        public virtual async Task<T> UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(t => t.Id == entity.Id, entity, new ReplaceOptions(){ IsUpsert = false });
            return entity;
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Entities</returns>
        public virtual IEnumerable<T> Update(IEnumerable<T> entities)
        {
            foreach(T entity in entities)
            {
                Update(entity);
            }

            return entities;
        }

        /// <summary>
        /// Update entities async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Entities</returns>
        public virtual async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities)
        {
            await Task.WhenAll(entities.Select(UpdateAsync));
            return entities;
        }

        

        #endregion

    }
}