using Common.Query;
using Microsoft.EntityFrameworkCore;
using Mst.AuthManager.Infrastructure.Persistent.Ef;
using Mst.AuthManager.Query.RoleAgg.Dtos;

namespace Mst.AuthManager.Query.RoleAgg.GetList;

public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
{
    public GetRoleListQueryHandler(ApplicationDbContext context)
    {
        Context = context;
    }

    private ApplicationDbContext Context { get; }

    public Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        var result = Context.Roles.Select(role => new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        }).ToListAsync();

        return result;
    }
}