
using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Mst.AuthManager.Infrastructure.Persistent.Ef;
using Mst.AuthManager.Query.UserAgg.Dtos;

namespace Mst.AuthManager.Query.UserAgg.GetList;

public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, List<UserDto>>
{
    public GetUserListQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    private ApplicationDbContext Context { get; }
    private IMapper Mapper { get; }

    public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users =await Context.Users.ToListAsync();

        var usersDto = Mapper.Map<List<UserDto>>(users);

        return usersDto;
    }
}