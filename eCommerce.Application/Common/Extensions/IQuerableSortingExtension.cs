using System.Linq.Dynamic.Core;

namespace eCommerce.Application.Common.Extensions
{
    public class EntityTypeDescriptor
    {
        public static readonly IEnumerable<string> ForbiddenSortOptions = new HashSet<string> { "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "IsRemoved" };
        public HashSet<string> SortOptions { get; } = new HashSet<string>();

        public EntityTypeDescriptor(Type entity)
        {
            SortOptions = GetSortOptions(entity);
        }

        public string GetSortExpression(string sortStr)
        {
            var sortStringArray = sortStr.Split(',');

            string sortExpression = string.Empty;

            foreach (var sortOption in sortStringArray)
            {
                if (sortOption.StartsWith("-"))
                {
                    var prop = sortOption.Remove(0, 1);
                    if (SortOptions.Contains(prop))
                        sortExpression += prop + " DESC,";
                }
                else
                {
                    if (SortOptions.Contains(sortOption))
                        sortExpression += sortOption + " ASC,";
                }
            }
            return sortExpression;
        }

        private static HashSet<string> GetSortOptions(Type type)
        {
            var result = type.GetProperties()
                            .Where(x => !ForbiddenSortOptions.Contains(x.Name))
                            .Select(x => x.Name)
                            .ToHashSet();

            return result ?? new HashSet<string>();
        }
    }

    public static class IQuerableSortingExtension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string? sortStr)
        {
            var descriptor = new EntityTypeDescriptor(typeof(T));

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Data source is empty");
            }
            if (descriptor.SortOptions is null)
            {
                throw new ArgumentNullException(nameof(descriptor.SortOptions), "no Sort options avaiable");
            }
            if (string.IsNullOrEmpty(sortStr))
            {
                return source.OrderBy("Id");
            }

            var sortExpression = descriptor.GetSortExpression(sortStr);

            if (!string.IsNullOrWhiteSpace(sortExpression))
            {
                // Note: system.linq.dynamic NuGet package is required here to operate OrderBy on string
                source = source.OrderBy(sortExpression.Remove(sortExpression.Length - 1));
            }

            return source;
        }
    }
}