namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaGalleryItems(int UserId, PageInfo PageInfo, MemorabiliaSearchCriteria Filter = null) : IQuery<MemorabiliaGalleryItemsViewModel>
{
    public class Handler : QueryHandler<GetMemorabiliaGalleryItems, MemorabiliaGalleryItemsViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaGalleryItemsViewModel> Handle(GetMemorabiliaGalleryItems query)
        {
            var result = await _memorabiliaRepository.GetAll(query.UserId, query.PageInfo, query.Filter);

            return new MemorabiliaGalleryItemsViewModel(result.Data, result.PageInfo);
        }
    }
}
