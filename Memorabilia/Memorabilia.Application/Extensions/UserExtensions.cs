namespace Memorabilia.Application.Extensions;

public static class UserExtensions
{
    public static bool HasPermission(this Entity.User user, Constant.Permission permission)
        => user != null && 
           user.UserPermissionIds().Contains(permission.Id);

    public static bool HasPermission(this Entity.User user, int permissionId)
        => user != null && 
           user.UserPermissionIds().Contains(permissionId);

    public static bool HasRole(this Entity.User user, Constant.Role role)
        => user != null && 
           user.Roles.Any(userRole => userRole.Id == role.Id);

    public static bool HasRole(this Entity.User user, int roleId)
       => user != null && 
          user.Roles.Any(userRole => userRole.Id == roleId);

    public static bool IsActiveMember(this Entity.User user)
        => user != null && 
           user.SubscriptionExpirationDate.IsActive() && 
           user.Roles.Any(role => Constant.Role.MembershipRoles.Contains(Constant.Role.Find(role.RoleId)));

    public static bool IsActiveSubscriber(this Entity.User user)
        => user != null &&
           user.SubscriptionExpirationDate.IsActive() &&
           !user.StripeSubscriptionId.IsNullOrEmpty() &&
           user.Roles.Any(role => Constant.Role.MembershipRoles.Contains(Constant.Role.Find(role.RoleId)));

    public static bool IsAdmin(this Entity.User user)
        => user != null && 
           user.Roles.Any(role => role.Id == Constant.Role.Admin.Id);

    public static bool IsMembershipExpired(this Entity.User user)
        => user != null &&
           user.SubscriptionExpirationDate.HasValue &&
           user.SubscriptionExpirationDate.Value < DateTime.UtcNow;

    public static bool IsUpgradeEligible(this Entity.User user)
        => user != null && 
           user.Roles.All(role => !Constant.Role.HighestLevelRoles.Contains(Constant.Role.Find(role.RoleId)));

    public static string MembershipStatus(this Entity.User user)
        => user != null && 
           user.SubscriptionExpirationDate.HasValue &&
           user.SubscriptionExpirationDate.Value <DateTime.UtcNow
               ? (user.SubscriptionCanceled? "Canceled" : "Expired")
               : "Active";

    public static int[] UserPermissionIds(this Entity.User user)
        => user.Roles
               .SelectMany(userRole => userRole.Role.Permissions)
               .DistinctBy(rolePermission => rolePermission.Id)
               .Select(rolePermission => rolePermission.PermissionId)
               .ToArray();

    public static Constant.Permission[] UserPermissions(this Entity.User user)
        => user.Roles
               .SelectMany(userRole => userRole.Role.Permissions)
               .DistinctBy(rolePermission => rolePermission.Id)
               .Select(rolePermission => Constant.Permission.Find(rolePermission.PermissionId))               
               .ToArray();
}
