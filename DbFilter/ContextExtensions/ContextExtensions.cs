using DbFilter.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DbFilter.ContextExtensions;

public static class ContextExtensions
{
    public static IQueryable<SecretTable> CheckPermission(this AppDbContext dbContext, int ownerId, int requestId)
    {
        return dbContext.SecretTables
            .Where(table => table.IdOwner == ownerId)
            .Where(table => table.AllowedUsers.Split().Contains(requestId.ToString()));
    }
}