using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace DbFilter.Filter;

public class EntityPermissionFilter: IPermissionFilter<Entity>
{
    public EntityPermissionFilter(DbContext dbContext, IIdentity identity)
        : base(dbContext, identity)
    {
    }

    public override IQueryable<Practice> GetPermitted(
        IQueryable<Practice> queryable)
    {
        return DbContext
            .Set<Practice>()
            .WhereIf(User.OrganizationType == OrganizationType.Client,
                x => x.Manager.OrganizationId == User.OrganizationId)
            .WhereIf(User.OrganizationType == OrganizationType.StaffingAgency,
                x => x.Partners
                    .Select(y => y.OrganizationId)
                    .Contains(User.OrganizationId));
    }
}