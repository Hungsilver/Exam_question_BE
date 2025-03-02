using Exam_question_BE.HS.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exam_question_BE.HS.Core.Helpers
{
    public static class FilterExtension
    {
        public static IQueryable<T> ApplySort<T>(
            this IQueryable<T> query,
                string sortOrder
            )
        {
            if (string.IsNullOrEmpty(sortOrder))
            {
                return query;
            }
            bool descending = false;
            if (sortOrder.EndsWith("_desc"))
            {
                sortOrder = sortOrder[..^5]; // viet tat thay cho substring tu 0-> sort.leng -5
                descending = true;
            }
            // Kiểm tra property tồn tại
            var type = typeof(T);
            var property = type.GetProperty(sortOrder);
            if (property == null)
                throw new BadRequestException($"Property {sortOrder} không tồn tại trong type {type.Name}");

            return descending
                ? query.OrderByDescending(e => EF.Property<object>(e!, sortOrder))
                : query.OrderBy(e => EF.Property<object>(e!, sortOrder));
        }

        public static IQueryable<T> ApplyFilter<T>(
            this IQueryable<T> query,
            string propertyName,
            string searchStr)
        {
            if (string.IsNullOrEmpty(searchStr))
            {
                return query;
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var searchConstant = Expression.Constant(searchStr);

            var containsExpression = Expression.Call(property, containsMethod, searchConstant);
            var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);

            return query.Where(lambda);
        }

        // Overload cho nhiều điều kiện filter
        public static IQueryable<T> ApplyMultipleFilters<T>(
            this IQueryable<T> query,
            Dictionary<string, string> filters) //key - value
        {
            foreach (var filter in filters)
            {
                query = query.ApplyFilter(filter.Key, filter.Value);
            }
            return query;
        }
    }
}
