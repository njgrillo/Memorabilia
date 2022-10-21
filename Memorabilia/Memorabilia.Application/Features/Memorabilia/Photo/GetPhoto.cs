namespace Memorabilia.Application.Features.Memorabilia.Photo;

public record GetPhoto(int MemorabiliaId) : IQuery<PhotoViewModel>
{
    public class Handler : QueryHandler<GetPhoto, PhotoViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PhotoViewModel> Handle(GetPhoto query)
        {
            return new PhotoViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }
}
