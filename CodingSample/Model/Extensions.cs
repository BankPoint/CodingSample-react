using System.Linq.Expressions;

namespace CodingSample.Model
{
    public static class Extensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortColumn, string direction)
        {
            var methodName = string.Format("OrderBy{0}", "Descending".Equals(direction, StringComparison.OrdinalIgnoreCase) ? "Descending" : "");
            var parameter = Expression.Parameter(query.ElementType, "p");
            MemberExpression memberAccess = null;
            foreach (var property in sortColumn.Split('.'))
            {
                memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
            }
            var orderByLambda = Expression.Lambda(memberAccess, parameter);
            MethodCallExpression result = Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { query.ElementType, memberAccess.Type },
                query.Expression,
                Expression.Quote(orderByLambda));
            return query.Provider.CreateQuery<T>(result);
        }
    }
}
