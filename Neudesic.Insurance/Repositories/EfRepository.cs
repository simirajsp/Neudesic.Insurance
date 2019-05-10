using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Neudesic.Insurance.Models.Dto;
using Neudesic.Insurance.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Neudesic.Insurance.Repositories
{
    /// <summary>
    /// Default implementation of IRepository using entity framework
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public EfRepository(DbContext context)
        {
            _context = context;
        }

        public SaveResult<TEntity> Create(TEntity data)
        {
            return Create(new List<TEntity> { data }).First();
        }

        public IEnumerable<SaveResult<TEntity>> Create(IEnumerable<TEntity> data)
        {
            try
            {
                _context.Set<TEntity>().AddRange(data);
                _context.SaveChanges();

                return ConvertToSuccessResult(data);

            }
            catch (DbUpdateException ex)
            {
                return ConvertToErrorResult(ex);
            }
        }

        public SaveResult<TEntity> Delete(int id)
        {
            return Delete(new List<int> { id }).First();
        }

        public IEnumerable<SaveResult<TEntity>> Delete(IEnumerable<int> ids)
        {
            IEnumerable<TEntity> entities = _context.Set<TEntity>().Where(ent => ids.Contains(ent.Id)).ToList();

            try
            {
                _context.Set<TEntity>().RemoveRange(entities);

                _context.SaveChanges();
                return ConvertToSuccessResult(entities);
            }
            catch(DbUpdateException ex)
            {
                return ConvertToErrorResult(ex);
            }
        }

        public IEnumerable<TEntity> FindAll(int maxRecordsToRetrieve = 100)
        {
            return _context.Set<TEntity>().Take(maxRecordsToRetrieve).ToList();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public PaginatedResponse<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, PaginationRequest pagination)
        {
            // todo: validate inputs

            var query = _context.Set<TEntity>().Where(predicate);

            var result = new PaginatedResponse<TEntity>
            {
                PageNumber = pagination.PageNumber,
                TotalNumberOfRecords = query.Count(),
                CurrentPageData = query.Skip((pagination.PageNumber - 1) * pagination.RecordsPerPage).Take(pagination.RecordsPerPage).ToList()
            };

            return result;
        }

        public TEntity FindById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public SaveResult<TEntity> Update(TEntity data)
        {
            return Update(new List<TEntity> { data }).First();
        }

        public IEnumerable<SaveResult<TEntity>> Update(IEnumerable<TEntity> data)
        {
            try
            {
                // Load entities in context
                List<int> ids = data.Select(ent => ent.Id).ToList();
                IEnumerable<TEntity> originalEntities = _context.Set<TEntity>().Where(ent => ids.Contains(ent.Id));


                // Join current & updated entries and update in context 
                var combined = (from original in originalEntities
                                join modified in data on original.Id equals modified.Id
                                select new { Original = original, Modified = modified }).ToList();

                combined.ForEach(ent =>
                {
                    // Get the entry from context and update values
                    // EF's feature is used here to avoid delegates and reflection
                    EntityEntry<TEntity> entry = _context.Entry(ent.Original);
                    entry.CurrentValues.SetValues(ent.Modified);

                });

                _context.SaveChanges();
                return ConvertToSuccessResult(data);
            }
            catch (DbUpdateException ex)
            {
                return ConvertToErrorResult(ex);
            }
        }

        private IEnumerable<SaveResult<TEntity>> ConvertToErrorResult(DbUpdateException exception)
        {
            string message = exception.Message + Environment.NewLine + exception.InnerException?.Message;

            return exception.Entries.Select(entry => new SaveResult<TEntity>
            {
                IsSuccess = false,
                Data = entry.Entity as TEntity,
                Message = message
            }).ToList();
        }

        private IEnumerable<SaveResult<TEntity>> ConvertToSuccessResult(IEnumerable<TEntity> data)
        {
            return data.Select(ent => new SaveResult<TEntity> { IsSuccess = true, Data = ent }).ToList();
        }
    }
}
