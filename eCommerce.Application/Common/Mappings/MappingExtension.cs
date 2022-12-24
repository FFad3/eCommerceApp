using AutoMapper.QueryableExtensions;
using AutoMapper;
using eCommerce.Application.DTOs.Common;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Application.Common.Mappings
{
    public static class MappingExtension
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
            where TDestination : class
       => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize, cancellationToken);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration, CancellationToken cancellationToken)
            where TDestination : class
            => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync(cancellationToken);
    }
}