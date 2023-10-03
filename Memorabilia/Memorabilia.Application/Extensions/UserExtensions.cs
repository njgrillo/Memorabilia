using System.Linq;

namespace Memorabilia.Application.Extensions;

public static class UserExtensions
{
    public static bool HasPermission(this Entity.User user, Constant.Permission permission)
        => user != null && user.UserPermissionIds().Contains(permission.Id);

    public static bool HasPermission(this Entity.User user, int permissionId)
        => user != null && user.UserPermissionIds().Contains(permissionId);

    public static bool HasRole(this Entity.User user, Constant.Role role)
        => user != null && user.Roles.Any(userRole => userRole.Id == role.Id);

    public static bool HasRole(this Entity.User user, int roleId)
       => user != null && user.Roles.Any(userRole => userRole.Id == roleId);

    public static bool IsAdmin(this Entity.User user)
        => user != null && user.Roles.Any(role => role.Id == Constant.Role.Admin.Id);

    public static bool IsUpgradeEligible(this Entity.User user)
        => user != null && user.Roles.All(role => !Constant.Role.HighestLevelRoles.Contains(Constant.Role.Find(role.Id)));

    public static int[] UserPermissionIds(this Entity.User user)
        => user.Roles
               .SelectMany(userRole => userRole.Role.Permissions)
               .DistinctBy(permission => permission.Id)
               .Select(permission => permission.Id)
               .ToArray();

    public static Constant.Permission[] UserPermissions(this Entity.User user)
        => user.Roles
               .SelectMany(userRole => userRole.Role.Permissions)
               .DistinctBy(permission => permission.Id)
               .Select(permission => Constant.Permission.Find(permission.Id))               
               .ToArray();
}
