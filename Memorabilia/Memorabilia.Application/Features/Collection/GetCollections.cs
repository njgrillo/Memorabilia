namespace Memorabilia.Application.Features.Collection;

public record GetCollections(int UserId) : IQuery<CollectionsViewModel>
{
    public class Handler : QueryHandler<GetCollections, CollectionsViewModel>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task<CollectionsViewModel> Handle(GetCollections query)
        {
            var collections = (await _collectionRepository.GetAll(query.UserId))
                                                          .OrderBy(collection => collection.Name);

            return new CollectionsViewModel(collections);
        }
    }
}
