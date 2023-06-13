namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaGalleryItems(PageInfo PageInfo, 
                                         MemorabiliaSearchCriteria Filter = null) 
    : IQuery<MemorabiliaGalleryItemsModel>
{
    public class Handler : QueryHandler<GetMemorabiliaGalleryItems, MemorabiliaGalleryItemsModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository, 
                       IApplicationStateService applicationStateService)
        {
            _memorabiliaRepository = memorabiliaRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<MemorabiliaGalleryItemsModel> Handle(GetMemorabiliaGalleryItems query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await _memorabiliaRepository.GetAll(_applicationStateService.CurrentUser.Id, 
                                                      query.PageInfo, 
                                                      query.Filter);

            return new MemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
