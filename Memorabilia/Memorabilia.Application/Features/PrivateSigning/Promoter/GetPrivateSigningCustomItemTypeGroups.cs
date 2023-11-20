namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record GetPrivateSigningCustomItemTypeGroups() : IQuery<Entity.PrivateSigningCustomItemTypeGroup[]>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IPrivateSigningCustomItemTypeGroupRepository privateSigningCustomItemTypeGroupRepository) 
        : QueryHandler<GetPrivateSigningCustomItemTypeGroups, Entity.PrivateSigningCustomItemTypeGroup[]>
    {
        protected override async Task<Entity.PrivateSigningCustomItemTypeGroup[]> Handle(GetPrivateSigningCustomItemTypeGroups query)
            => (await privateSigningCustomItemTypeGroupRepository.GetAll(applicationStateService.CurrentUser.Id))
                   .ToArray();
    }
}
