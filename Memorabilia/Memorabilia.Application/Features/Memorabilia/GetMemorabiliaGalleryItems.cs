namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaGalleryItems(int UserId) : IQuery<MemorabiliaGalleryItemsViewModel>
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
            return new MemorabiliaGalleryItemsViewModel(await _memorabiliaRepository.GetAll(query.UserId));
        }
    }
}
