using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Mst.AuthManager.Infrastructure.Persistent.Ef;
using Mst.AuthManager.Query.RoleAgg.Dtos;

namespace Mst.AuthManager.Query.RoleAgg.GetById;

public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
{
    public GetRoleByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    private ApplicationDbContext Context { get;}
    private IMapper Mapper { get; }

    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await Context.Roles.FirstOrDefaultAsync(x => x.Id == request.RoleId, cancellationToken);

        if (role == null)
            return null;

        var roleDto = Mapper.Map<RoleDto>(role);
        roleDto.Permissions = role.Permissions.Select(s => s.Permission).ToList();
        return roleDto;     
    }
}

