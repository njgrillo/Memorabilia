namespace Memorabilia.Application.Features.Collection;

public record GetCollection(int Id) : IQuery<Domain.Entities.Collection>
{
    public class Handler : QueryHandler<GetCollection, Domain.Entities.Collection>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task<Domain.Entities.Collection> Handle(GetCollection query)
        {
            return await _collectionRepository.Get(query.Id);
        }
    }
}
