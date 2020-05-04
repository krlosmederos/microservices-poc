using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDataAccess.API.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MongoDataAccess.API.Infrastructure.Repositories
{
    public interface IMongoDbRepository<T> where T : BaseEntity
    {
        IMongoCollection<T> Collection { get; }

        IMongoDatabase Database { get; }

        /// <summary>
        /// Get all entities 
        /// </summary>
        /// <returns>Mongo Queryable of entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get entity by identifier 
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(string id);

        /// <summary>
        /// Get entity by identifier async
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        T Insert(T entity);

        /// <summary>
        /// Insert entity async
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Entities</returns>
        IEnumerable<T> Insert(IEnumerable<T> entities);

        /// <summary>
        /// Insert entities async
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>Entities</returns>
        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity</returns>
        T Update(T entity);

        /// <summary>
        /// Update entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Entities</returns>
        IEnumerable<T> Update(IEnumerable<T> entities);

        /// <summary>
        /// Update entities async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>Entities</returns>
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);

    }
}