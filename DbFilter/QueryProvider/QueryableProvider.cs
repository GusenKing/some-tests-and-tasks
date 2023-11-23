using System.Reflection;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;


namespace DbFilter.QueryProvider;

public class QueryableProvider: IQueryableProvider
{
    // ищем фильтры и запоминаем их типы
    private static Type[] Filters = typeof(PermissionFilter<>)
        .Assembly
        .GetTypes()
        .Where(x => x.GetInterfaces().Any(y =>
            y.IsGenericType && y.GetGenericTypeDefinition() 
            == typeof(IPermissionFilter<>)))
        .ToArray();
                
    private readonly DbContext _dbContext;
    private readonly IIdentity _identity;

    public QueryableProvider(DbContext dbContext, IIdentity identity)
    {
        _dbContext = dbContext;
        _identity = identity;
    }
        
    private static MethodInfo QueryMethod = typeof(QueryableProvider)
        .GetMethods()
        .First(x => x.Name == "Query" && x.IsGenericMethod);

    private IQueryable<T> Filter<T>(IQueryable<T> queryable)
        => Filters
            // ищем фильтры необходимого типа 
            .Where(x => x.GetGenericArguments().First() == typeof(T))
            // создаем все фильтры подходящего типа и применяем к Queryable<T> 
            .Aggregate(queryable, 
                (c, n) => ((dynamic)Activator.CreateInstance(n, 
                    _dbContext, _identity)).GetPermitted(queryable));
        
    public IQueryable<T> Query<T>() where T : class 
        => Filter(_dbContext.Set<T>());

    // из EF Core убрали Set(Type type), приходится писать самому :(
    public IQueryable Query(Type type)
        => (IQueryable)QueryMethod
            .MakeGenericMethod(type)
            .Invoke(_dbContext, new object[]{});
}