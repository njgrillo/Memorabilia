namespace Memorabilia.Application.Features.Collection;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record GetCollection(int Id) : IQuery<Entity.Collection>
{
    public class Handler(ICollectionRepository collectionRepository) 
        : QueryHandler<GetCollection, Entity.Collection>
    {
        protected override async Task<Entity.Collection> Handle(GetCollection query)
            => await collectionRepository.Get(query.Id);
    }
}
