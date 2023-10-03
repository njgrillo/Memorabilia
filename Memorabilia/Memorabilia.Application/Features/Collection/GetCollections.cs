namespace Memorabilia.Application.Features.Collection;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record GetCollections() : IQuery<Entity.Collection[]>
{
    public class Handler : QueryHandler<GetCollections, Entity.Collection[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository, 
                       IApplicationStateService applicationStateService)
        {
            _collectionRepository = collectionRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<Entity.Collection[]> Handle(GetCollections query)
            => (await _collectionRepository.GetAll(_applicationStateService.CurrentUser.Id))
                   .OrderBy(collection => collection.Name)
                   .ToArray();
    }
}
