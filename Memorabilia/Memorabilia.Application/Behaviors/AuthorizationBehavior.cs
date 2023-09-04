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

        AuthorizeAttribute[] authorizeAttributesWithRoles
            = authorizeAttributes.Where(authorizeAttribute => !authorizeAttribute.Roles.IsNullOrEmpty())
                                 .ToArray();

        if (!authorizeAttributesWithRoles.Any())
            return;

        foreach (string[] requiredPermissions in authorizeAttributesWithRoles.Select(authorizeAttribute => authorizeAttribute.Roles.Split(',')))
        {
            if (!requiredPermissions.Any(permission => permission.Equals("admin", StringComparison.OrdinalIgnoreCase)))
                continue;

            if (!_applicationStateService.CurrentUser.IsAdmin())
                throw new UnauthorizedAccessException();
        }        
    }
}
