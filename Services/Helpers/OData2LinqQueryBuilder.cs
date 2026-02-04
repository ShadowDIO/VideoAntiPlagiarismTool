using Microsoft.AspNetCore.OData.Query;
using OData2Linq;
using System.Text.RegularExpressions;

namespace Services.Helpers
{
    /// <summary>
    /// Translates incoming OData query options into a reusable LINQ transformer that
    /// can be applied to an IQueryable before mapping to DTOs.
    /// </summary>
    public static partial class OData2LinqQueryBuilder
    {
        /// <summary>
        /// Builds an OData query transformer, optionally excluding specific properties from the $filter.
        /// Use excludeFromFilter when certain properties should be handled manually (e.g., nested entity filters).
        /// </summary>
        /// <param name="options">The OData query options.</param>
        /// <param name="excludeFromFilter">Property names to remove from the $filter before applying OData.</param>
        public static Func<IQueryable<T>, IQueryable<T>>? Build<T>(
            ODataQueryOptions<T>? options,
            params string[] excludeFromFilter)
        {
            if (options is null)
                return null;

            var raw = options.RawValues;
            var filter = raw.Filter;

            // Remove excluded properties from the filter
            if (!string.IsNullOrWhiteSpace(filter) && excludeFromFilter.Length > 0)
            {
                filter = RemovePropertiesFromFilter(filter, excludeFromFilter);
            }

            var hasFilter = !string.IsNullOrWhiteSpace(filter);
            var hasOrderBy = !string.IsNullOrWhiteSpace(raw.OrderBy);
            var hasTopSkip = !string.IsNullOrWhiteSpace(raw.Top) || !string.IsNullOrWhiteSpace(raw.Skip);
            var hasSelect = false; // Select/Expand unsupported in this helper to avoid wrapper projections.

            if (!(hasFilter || hasOrderBy || hasSelect || hasTopSkip))
                return null;

            var top = raw.Top?.ToString() ?? options.Top?.Value.ToString();
            var skip = raw.Skip?.ToString() ?? options.Skip?.Value.ToString();

            return query =>
            {
                var odataQuery = query.OData();

                if (hasFilter)
                    odataQuery = odataQuery.Filter(filter);

                if (hasOrderBy)
                    odataQuery = odataQuery.OrderBy(raw.OrderBy);

                if (hasTopSkip)
                    odataQuery = odataQuery.TopSkip(top, skip);

                return odataQuery.ToOriginalQuery();
            };
        }

        /// <summary>
        /// Removes specific property filters from an OData $filter expression.
        /// Handles patterns like "PropertyName eq value" with surrounding "and" operators.
        /// </summary>
        private static string RemovePropertiesFromFilter(string filter, string[] propertiesToRemove)
        {
            var result = filter;

            foreach (var prop in propertiesToRemove)
            {
                // Pattern matches: "PropertyName eq value" with optional surrounding "and"
                // Handles: "and PropertyName eq 1", "PropertyName eq 1 and", "PropertyName eq 1"
                var patterns = new[]
                {
                    $@"\s+and\s+{Regex.Escape(prop)}\s+eq\s+\d+",  // " and PropertyName eq 1"
                    $@"{Regex.Escape(prop)}\s+eq\s+\d+\s+and\s+",  // "PropertyName eq 1 and "
                    $@"{Regex.Escape(prop)}\s+eq\s+\d+"            // "PropertyName eq 1" (standalone)
                };

                foreach (var pattern in patterns)
                {
                    result = Regex.Replace(result, pattern, "", RegexOptions.IgnoreCase);
                }
            }

            return result.Trim();
        }
    }
}
