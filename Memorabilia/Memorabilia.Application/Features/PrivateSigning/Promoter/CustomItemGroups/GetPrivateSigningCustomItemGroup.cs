namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record GetPrivateSigningCustomItemGroup(int Id) : IQuery<Entity.PrivateSigningCustomItemGroup>
{
    public class Handler(IPrivateSigningCustomItemGroupRepository privateSigningCustomItemGroupRepository)
        : QueryHandler<GetPrivateSigningCustomItemGroup, Entity.PrivateSigningCustomItemGroup>
    {
        protected override async Task<Entity.PrivateSigningCustomItemGroup> Handle(GetPrivateSigningCustomItemGroup query)
            => await privateSigningCustomItemGroupRepository.Get(query.Id);
    }
}
