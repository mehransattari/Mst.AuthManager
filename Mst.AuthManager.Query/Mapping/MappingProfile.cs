namespace Mst.AuthManager.Query.Mapping;

using AutoMapper;
using Mst.AuthManager.Domain.RoleAgg;
using Mst.AuthManager.Domain.UserAgg;
using Mst.AuthManager.Query.RoleAgg.Dtos;
using Mst.AuthManager.Query.UserAgg.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
