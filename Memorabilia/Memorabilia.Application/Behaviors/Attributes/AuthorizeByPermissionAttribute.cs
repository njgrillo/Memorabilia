namespace Memorabilia.Application.Behaviors.Attributes;

public class AuthorizeByPermissionAttribute : AuthorizeAttribute
{
    public AuthorizeByPermissionAttribute(params Enum.Permission[] permissions)
    {
        Policy = string.Join(",", permissions);
    }
}
