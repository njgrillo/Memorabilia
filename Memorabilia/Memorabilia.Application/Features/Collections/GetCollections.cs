namespace Memorabilia.Application.Features.Collections;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record GetCollections() : IQuery<Entity.Collection[]>
{
    public class Handler(ICollectionRepository collectionRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetCollections, Entity.Collection[]>
    {
        protected override async Task<Entity.Collection[]> Handle(GetCollections query)
            => (await collectionRepository.GetAll(applicationStateService.CurrentUser.Id))
                   .OrderBy(collection => collection.Name)
                   .ToArray();
    }
}
