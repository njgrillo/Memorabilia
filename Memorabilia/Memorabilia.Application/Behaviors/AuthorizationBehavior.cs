namespace Memorabilia.Application.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> 
    : PipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IApplicationStateService _applicationStateService;

	public AuthorizationBehavior(IApplicationStateService applicationStateService)
	{
        _applicationStateService = applicationStateService;
	}

    public override async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> 
        next, 
        CancellationToken cancellation)
    {
        CheckSecurity(request);

        return await next();
    }

    private void CheckSecurity(TRequest request)
    {   
        AuthorizeAttribute[] authorizeAttributes 
            = request.GetType()
                     .GetCustomAttributes<AuthorizeAttribute>()
                     .ToArray();

        if (!authorizeAttributes.Any())
            return;

        CheckUserMembership();
        CheckPermissions(authorizeAttributes);
        CheckRoles(authorizeAttributes);       
    }    

    private void CheckPermissions(AuthorizeAttribute[] authorizeAttributes)
    {
        AuthorizeAttribute[] authorizeAttributesWithPermissions
            = authorizeAttributes.Where(authorizeAttribute => !authorizeAttribute.Policy.IsNullOrEmpty())
                                 .ToArray();

        if (!authorizeAttributesWithPermissions.Any())
            return;

        foreach (string[] requiredPermissions in authorizeAttributesWithPermissions.Select(authorizeAttribute => authorizeAttribute.Policy.Split(',')))
        {
            Constant.Permission[] permissions
                = requiredPermissions.Select(Constant.Permission.FindByName)
                                     .ToArray();

            foreach (Constant.Permission permission in permissions)
            {
                if (_applicationStateService.CurrentUser.HasPermission(permission))
                    return;
            }

            throw new UnauthorizedAccessException();
        }
    }

    private void CheckRoles(AuthorizeAttribute[] authorizeAttributes)
    {
        AuthorizeAttribute[] authorizeAttributesWithRoles
            = authorizeAttributes.Where(authorizeAttribute => !authorizeAttribute.Roles.IsNullOrEmpty())
                                 .ToArray();

        if (!authorizeAttributesWithRoles.Any())
            return;

        foreach (string[] requiredRoles in authorizeAttributesWithRoles.Select(authorizeAttribute => authorizeAttribute.Roles.Split(',')))
        {
            Constant.Role[] roles
                = requiredRoles.Select(Constant.Role.FindByName)
                               .ToArray();

            foreach (Constant.Role role in roles)
            {
                if (_applicationStateService.CurrentUser.HasRole(role))
                    return;
            }

            throw new UnauthorizedAccessException();
        }
    }

    private void CheckUserMembership()
    {
        if (_applicationStateService.CurrentUser == null || !_applicationStateService.CurrentUser.IsMembershipExpired())
            return;

        throw new UnauthorizedAccessException();
    }
}
