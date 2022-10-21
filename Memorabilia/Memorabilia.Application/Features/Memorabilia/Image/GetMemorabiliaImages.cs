namespace Memorabilia.Application.Features.Memorabilia.Image;

public record GetMemorabiliaImages(int MemorabiliaId) : IQuery<MemorabiliaImagesViewModel>
{
    public class Handler : QueryHandler<GetMemorabiliaImages, MemorabiliaImagesViewModel>
    {
        private readonly IMemorabiliaImageRepository _memorabiliaImageRepository;

        public Handler(IMemorabiliaImageRepository memorabiliaImageRepository)
        {
            _memorabiliaImageRepository = memorabiliaImageRepository;
        }

        protected override async Task<MemorabiliaImagesViewModel> Handle(GetMemorabiliaImages query)
        {
            return new MemorabiliaImagesViewModel(await _memorabiliaImageRepository.GetAll(query.MemorabiliaId));
        }
    }
}
