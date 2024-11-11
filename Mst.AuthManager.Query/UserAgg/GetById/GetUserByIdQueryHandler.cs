using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Mst.AuthManager.Infrastructure.Persistent.Ef;
using Mst.AuthManager.Query.UserAgg.Dtos;

namespace Mst.AuthManager.Query.UserAgg.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    public GetUserByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    private ApplicationDbContext Context { get; }
    private IMapper Mapper { get; }


    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user =await Context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user == null)
            return null;

        var userDto = Mapper.Map<UserDto>(user);
        userDto.Roles = user.Roles.Select(x => new UserRoleDto()
        {
            RoleId = x.RoleId,
            RoleTitle = "",
        }).ToList();
        return userDto; 
    }
}