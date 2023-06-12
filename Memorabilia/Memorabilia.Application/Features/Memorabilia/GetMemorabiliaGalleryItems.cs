namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaGalleryItems(int UserId, 
                                         PageInfo PageInfo, 
                                         MemorabiliaSearchCriteria Filter = null) 
    : IQuery<MemorabiliaGalleryItemsModel>
{
    public class Handler : QueryHandler<GetMemorabiliaGalleryItems, MemorabiliaGalleryItemsModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaGalleryItemsModel> Handle(GetMemorabiliaGalleryItems query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await _memorabiliaRepository.GetAll(query.UserId, query.PageInfo, query.Filter);

            return new MemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
