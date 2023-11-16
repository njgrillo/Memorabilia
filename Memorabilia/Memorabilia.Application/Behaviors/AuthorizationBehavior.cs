namespace Memorabilia.Application.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse>(IApplicationStateService applicationStateService)
    : PipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
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

        if (authorizeAttributes.Length == 0)
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

        if (authorizeAttributesWithPermissions.Length == 0)
            return;

        foreach (string[] requiredPermissions in authorizeAttributesWithPermissions.Select(authorizeAttribute => authorizeAttribute.Policy.Split(',')))
        {
            Constant.Permission[] permissions
                = requiredPermissions.Select(Constant.Permission.FindByName)
                                     .ToArray();

            foreach (Constant.Permission permission in permissions)
            {
                if (applicationStateService.CurrentUser.HasPermission(permission))
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

        if (authorizeAttributesWithRoles.Length == 0)
            return;

        foreach (string[] requiredRoles in authorizeAttributesWithRoles.Select(authorizeAttribute => authorizeAttribute.Roles.Split(',')))
        {
            Constant.Role[] roles
                = requiredRoles.Select(Constant.Role.FindByName)
                               .ToArray();

            foreach (Constant.Role role in roles)
            {
                if (applicationStateService.CurrentUser.HasRole(role))
                    return;
            }

            throw new UnauthorizedAccessException();
        }
    }

    private void CheckUserMembership()
    {
        if (applicationStateService.CurrentUser == null || !applicationStateService.CurrentUser.IsMembershipExpired())
            return;

        throw new UnauthorizedAccessException();
    }
}
