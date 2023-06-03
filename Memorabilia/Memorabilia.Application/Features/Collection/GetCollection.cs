namespace Memorabilia.Application.Features.Collection;

public record GetCollection(int Id) : IQuery<CollectionViewModel>
{
    public class Handler : QueryHandler<GetCollection, CollectionViewModel>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task<CollectionViewModel> Handle(GetCollection query)
        {
            return new CollectionViewModel(await _collectionRepository.Get(query.Id));
        }
    }
}
