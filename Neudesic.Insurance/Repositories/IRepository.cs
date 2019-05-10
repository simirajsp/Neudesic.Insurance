using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Repositories
{
    /// <summary>
    /// Common abstraction for all repositories that need to support CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity:BaseEntity
    {
        /// <summary>
        /// Finds entity with given primary key. Will return null if entity do not exist
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        TEntity FindById(int id);

        /// <summary>
        /// Find all entities of given type. Optinally specify max records to be retrieved. Default is 100
        /// </summary>
        /// <param name="maxRecordsToRetrieve">Max records to be retrieved. Default is 100</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(int maxRecordsToRetrieve = 100);

        /// <summary>
        /// Find entities satisfying given predicate
        /// </summary>
        /// <param name="predicate">Predicate to be applied</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find entities satisfying given predicate
        /// </summary>
        /// <param name="predicate">Predicate to be applied</param>
        /// <returns></returns>
        PaginatedResponse<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, PaginationRequest pagination);

        /// <summary>
        /// Create new entity in database. This will create children if specified
        /// </summary>
        /// <param name="data">Entity to be created</param>
        /// <returns></returns>
        SaveResult<TEntity> Create(TEntity data);

        /// <summary>
        /// Create new entities in database. This will create children if specified
        /// </summary>
        /// <param name="data">Entities to be created</param>
        /// <returns></returns>
        IEnumerable<SaveResult<TEntity>> Create(IEnumerable<TEntity> data);

        /// <summary>
        /// Updates an entity in database. This will update only changed fields and clears fields listed in fieldsToNull.
        /// Also this will not update any navigation properties
        /// </summary>
        /// <param name="data">Entity to be updated</param>
        /// <returns></returns>
        SaveResult<TEntity> Update(TEntity data);

        /// <summary>
        /// Updates entities in database. This will update only changed fields and clears fields listed in fieldsToNull.
        /// Also this will not update any navigation properties
        /// </summary>
        /// <param name="data">Entities to be updated</param>
        /// <returns></returns>
        IEnumerable<SaveResult<TEntity>> Update(IEnumerable<TEntity> data);

        /// <summary>
        /// Deletes the given entity
        /// </summary>
        /// <param name="id">Id of entity to be deleted</param>
        /// <returns></returns>
        SaveResult<TEntity> Delete(int id);

        /// <summary>
        /// Deletes given entities from db
        /// </summary>
        /// <param name="ids">Ids of entities to be deleted</param>
        /// <returns></returns>
        IEnumerable<SaveResult<TEntity>> Delete(IEnumerable<int> ids);
    }
}
