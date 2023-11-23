namespace DbFilter.QueryProvider;

public interface IQueryableProvider
{
    IQueryable<T> Query<T>() where T: class;
        
    IQueryable Query(Type type);
}