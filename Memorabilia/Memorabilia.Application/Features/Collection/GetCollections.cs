namespace Memorabilia.Application.Features.Collection;

public record GetCollections(int UserId) : IQuery<Domain.Entities.Collection[]>
{
    public class Handler : QueryHandler<GetCollections, Domain.Entities.Collection[]>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task<Domain.Entities.Collection[]> Handle(GetCollections query)
        {
            return (await _collectionRepository.GetAll(query.UserId))
                       .OrderBy(collection => collection.Name)
                       .ToArray();
        }
    }
}
