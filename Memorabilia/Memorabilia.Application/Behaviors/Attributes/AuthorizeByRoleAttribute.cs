namespace Memorabilia.Application.Behaviors.Attributes;

public class AuthorizeByRoleAttribute : AuthorizeAttribute
{
	public AuthorizeByRoleAttribute(params Enum.PermissionType[] permissionTypes)
	{
		Roles = string.Join(",", permissionTypes);	
	}
}
