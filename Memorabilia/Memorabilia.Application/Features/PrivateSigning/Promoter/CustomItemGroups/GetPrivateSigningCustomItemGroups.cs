namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record GetPrivateSigningCustomItemGroups() : IQuery<Entity.PrivateSigningCustomItemGroup[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IPrivateSigningCustomItemGroupRepository privateSigningCustomItemGroupRepository) 
        : QueryHandler<GetPrivateSigningCustomItemGroups, Entity.PrivateSigningCustomItemGroup[]>
    {
        protected override async Task<Entity.PrivateSigningCustomItemGroup[]> Handle(GetPrivateSigningCustomItemGroups query)
            => (await privateSigningCustomItemGroupRepository.GetAll(applicationStateService.CurrentUser.Id))
                   .OrderBy(collection => collection.Name)
                   .ToArray();
    }
}
