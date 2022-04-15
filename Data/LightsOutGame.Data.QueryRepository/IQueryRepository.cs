using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LightsOutGame.Data.QueryRepo
{
    public interface IQueryRepository
    {
        void SetDbContext(DbContext dbContext);
        IQueryable<TEntity> GetQueryable<TEntity>()
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(bool asNoTracking, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            bool asNoTracking,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(
            Expression<Func<TEntity, bool>> condition,
            bool asNoTracking,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            bool asNoTracking = false,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(Specification<TEntity> specification, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TEntity>> GetListAsync<TEntity>(Specification<TEntity> specification, bool asNoTracking, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TProjectedType>> GetListAsync<TEntity, TProjectedType>(
            Expression<Func<TEntity, TProjectedType>> selectExpression,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<List<TProjectedType>> GetListAsync<TEntity, TProjectedType>(
           Expression<Func<TEntity, bool>> condition,
           Expression<Func<TEntity, TProjectedType>> selectExpression,
           CancellationToken cancellationToken = default)
           where TEntity : class;

        Task<List<TProjectedType>> GetListAsync<TEntity, TProjectedType>(
           Specification<TEntity> specification,
           Expression<Func<TEntity, TProjectedType>> selectExpression,
           CancellationToken cancellationToken = default)
           where TEntity : class;

        Task<PaginatedList<TEntity>> GetListAsync<TEntity>(
            PaginationSpecification<TEntity> specification,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<PaginatedList<TProjectedType>> GetListAsync<TEntity, TProjectedType>(
           PaginationSpecification<TEntity> specification,
           Expression<Func<TEntity, TProjectedType>> selectExpression,
           CancellationToken cancellationToken = default)
           where TEntity : class
           where TProjectedType : class;

        Task<TEntity> GetByIdAsync<TEntity>(object id, CancellationToken cancellationToken = default)
           where TEntity : class;

        Task<TEntity> GetByIdAsync<TEntity>(object id, bool asNoTracking, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<TEntity> GetByIdAsync<TEntity>(
            object id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<TEntity> GetByIdAsync<TEntity>(
            object id,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            bool asNoTracking,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<TProjectedType> GetByIdAsync<TEntity, TProjectedType>(
            object id,
            Expression<Func<TEntity, TProjectedType>> selectExpression,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default)
           where TEntity : class;

        Task<TEntity> GetAsync<TEntity>(
           Expression<Func<TEntity, bool>> condition,
           bool asNoTracking,
           CancellationToken cancellationToken = default)
           where TEntity : class;

        Task<TEntity> GetAsync<TEntity>(
           Expression<Func<TEntity, bool>> condition,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
           CancellationToken cancellationToken = default)
           where TEntity : class;

        Task<TEntity> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes,
            bool asNoTracking,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<TEntity> GetAsync<TEntity>(Specification<TEntity> specification, CancellationToken cancellationToken = default)
           where TEntity : class;

        Task<TEntity> GetAsync<TEntity>(Specification<TEntity> specification, bool asNoTracking, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<TProjectedType> GetAsync<TEntity, TProjectedType>(
            Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, TProjectedType>> selectExpression,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<TProjectedType> GetAsync<TEntity, TProjectedType>(
            Specification<TEntity> specification,
            Expression<Func<TEntity, TProjectedType>> selectExpression,
            CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<bool> ExistsAsync<TEntity>(CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<bool> ExistsByIdAsync<TEntity>(object id, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<int> GetCountAsync<TEntity>(CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<int> GetCountAsync<TEntity>(IEnumerable<Expression<Func<TEntity, bool>>> conditions, CancellationToken cancellationToken = default)
              where TEntity : class;

        Task<long> GetLongCountAsync<TEntity>(CancellationToken cancellationToken = default)
             where TEntity : class;

        Task<long> GetLongCountAsync<TEntity>(Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default)
            where TEntity : class;

        Task<long> GetLongCountAsync<TEntity>(IEnumerable<Expression<Func<TEntity, bool>>> conditions, CancellationToken cancellationToken = default)
             where TEntity : class;

        Task<List<T>> GetFromRawSqlAsync<T>(string sql, CancellationToken cancellationToken = default);

        Task<List<T>> GetFromRawSqlAsync<T>(string sql, object parameter, CancellationToken cancellationToken = default);

        Task<List<T>> GetFromRawSqlAsync<T>(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default);
    }
}
