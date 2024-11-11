using Common.Query.Filter;

namespace Mst.AuthManager.Query.UserAgg.Dtos;

public class UserFilterParams : BaseFilterParam
{
    public long? Id { get; set; }
    public string? UserName { get; set; }
}
