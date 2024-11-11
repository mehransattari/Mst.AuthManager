using Common.Query.Filter;

namespace Mst.AuthManager.Query.UserAgg.Dtos;

public class UserFilterData : BaseDto
{
    public string? UserName { get; set; }
}