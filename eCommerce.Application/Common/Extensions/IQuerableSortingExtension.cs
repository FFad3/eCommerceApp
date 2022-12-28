using eCommerce.Domain.Common;
using System.Linq.Dynamic.Core;

namespace eCommerce.Application.Common.Extensions
{
    public static class IQuerableSortingExtension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string? sortStr)
            where T : IEntityBase
        {
            var filters = GetFilters(typeof(T));

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Data source is empty");
            }
            if (filters is null)
            {
                throw new ArgumentNullException(nameof(filters), "avaiable filters are empty");
            }
            if (string.IsNullOrEmpty(sortStr))
            {
                return source.OrderBy(x => x.Id);
            }

            var sortStringArray = sortStr.Split(',');

            string sortExpression = string.Empty;

            foreach (var sortOption in sortStringArray)
            {
                if (sortOption.StartsWith("-"))
                {
                    var prop = sortOption.Remove(0, 1);
                    if (filters.Contains(prop))
                        sortExpression += prop + " DESC,";
                }
                else
                {
                    if (filters.Contains(sortOption))
                        sortExpression += sortOption + " ASC,";
                }
            }

            if (!string.IsNullOrWhiteSpace(sortExpression))
            {
                source.OrderBy("Name DESC");
                // Note: system.linq.dynamic NuGet package is required here to operate OrderBy on string
                source = source.OrderBy(sortExpression.Remove(sortExpression.Length - 1));
            }

            return source;
        }

        private static HashSet<string>? GetFilters(Type type)
        {
            var result = type.GetProperties()
                            .Where(x => typeof(AuditableEntity).GetProperty(x.Name) is null)
                            .Select(x => x.Name)
                            .ToHashSet();

            return result;
        }
    }
}