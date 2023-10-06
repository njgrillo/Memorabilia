namespace Memorabilia.Application.Behaviors.Attributes;

public class AuthorizeByRoleAttribute : AuthorizeAttribute
{
	public AuthorizeByRoleAttribute(params Enum.Role[] roles)
	{
		Roles = string.Join(",", roles);	
	}
}
