using Common.Query.Filter;

namespace Mst.AuthManager.Query.UserAgg.Dtos;

public class UserDto : BaseDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public List<UserRoleDto> Roles { get; set; } = new();
}
