using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LightsOutGame.Data.QueryRepo
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "The value of pageIndex must be greater than 0.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "The value of pageSize must be greater than 0.");
            }

            long count = await source.LongCountAsync(cancellationToken);

            int skipe = (pageIndex - 1) * pageSize;

            List<T> items = await source.Skip(skipe).Take(pageSize).ToListAsync(cancellationToken);

            PaginatedList<T> paginatedList = new PaginatedList<T>(items, count, pageIndex, pageSize);
            return paginatedList;
        }

        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            PaginationSpecification<T> specification,
            CancellationToken cancellationToken = default)
            where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }

            if (specification.PageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageIndex), $"The value of {nameof(specification.PageIndex)} must be greater than 0.");
            }

            if (specification.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(specification.PageSize), $"The value of {nameof(specification.PageSize)} must be greater than 0.");
            }

            IQueryable<T> countSource = source;

            if (specification.Conditions != null && specification.Conditions.Any())
            {
                foreach (Expression<Func<T, bool>> conditon in specification.Conditions)
                {
                    countSource = source.Where(conditon);
                }
            }

            long count = await countSource.LongCountAsync(cancellationToken);

            source = source.GetSpecifiedQuery(specification);
            List<T> items = await source.ToListAsync(cancellationToken);

            PaginatedList<T> paginatedList = new PaginatedList<T>(items, count, specification.PageIndex, specification.PageSize);
            return paginatedList;
        }
    }
}
