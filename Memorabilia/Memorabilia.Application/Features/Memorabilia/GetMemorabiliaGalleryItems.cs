namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaGalleryItems(PageInfo PageInfo, 
                                         MemorabiliaSearchCriteria Filter = null) 
    : IQuery<MemorabiliaGalleryItemsModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetMemorabiliaGalleryItems, MemorabiliaGalleryItemsModel>
    {
        protected override async Task<MemorabiliaGalleryItemsModel> Handle(GetMemorabiliaGalleryItems query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await memorabiliaRepository.GetAll(applicationStateService.CurrentUser.Id, 
                                                      query.PageInfo, 
                                                      query.Filter);

            return new MemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
