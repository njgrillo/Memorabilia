namespace Memorabilia.Application.Features.Collection;

public record GetCollections(int UserId) : IQuery<Entity.Collection[]>
{
    public class Handler : QueryHandler<GetCollections, Entity.Collection[]>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task<Entity.Collection[]> Handle(GetCollections query)
            => (await _collectionRepository.GetAll(query.UserId))
                   .OrderBy(collection => collection.Name)
                   .ToArray();
    }
}
