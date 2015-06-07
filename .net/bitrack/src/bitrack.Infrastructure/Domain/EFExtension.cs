using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace bitrack.Infrastructure.Domain
{
    public static class EFExtension
    {
        public static IQueryable<T> CustomWhere<T>(this IQueryable<T> source, string propertyName, string filterType, string value)
        {
            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "param");
            MemberExpression memberAccess = Expression.MakeMemberAccess(parameter, type.GetProperty(propertyName));
            Expression<Func<T, bool>> lambda;
            if (filterType == "Equal")
            {
                BinaryExpression methodExp = Expression.Equal(memberAccess, Expression.Constant(value));
                lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
            }
            else
            {
                MethodInfo method = memberAccess.Type.GetMethod(filterType);
                MethodCallExpression methodExp = Expression.Call(memberAccess, method, Expression.Constant(value));
                lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
            }
            return source.Where(lambda);
        }
    }
}
