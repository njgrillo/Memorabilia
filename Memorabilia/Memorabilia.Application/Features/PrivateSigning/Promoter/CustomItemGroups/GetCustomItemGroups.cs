namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record GetCustomItemGroups() : IQuery<Entity.PrivateSigningCustomItemGroup[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IPrivateSigningCustomItemGroupRepository privateSigningCustomItemGroupRepository)
        : QueryHandler<GetCustomItemGroups, Entity.PrivateSigningCustomItemGroup[]>
    {
        protected override async Task<Entity.PrivateSigningCustomItemGroup[]> Handle(GetCustomItemGroups query)
            => (await privateSigningCustomItemGroupRepository.GetAll(applicationStateService.CurrentUser.Id))
                   .OrderBy(group => group.Name)
                   .ToArray();
    }
}
