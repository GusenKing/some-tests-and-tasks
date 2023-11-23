namespace DbFilter.Filter;

public interface IPermissionFilter<T>
{
    IQueryable<T> GetPermitted(IQueryable<T> queryable);

}