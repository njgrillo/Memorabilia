namespace Memorabilia.Application.Extensions;

public static class UserExtensions
{
    public static bool IsAdmin(this Entity.User user)
        => user != null && user.UserRoleId == Constant.Role.Admin.Id;
}
