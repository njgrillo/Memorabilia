namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class GetPhoto
{
    public class Handler : QueryHandler<Query, PhotoViewModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<PhotoViewModel> Handle(Query query)
        {
            return new PhotoViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId));
        }
    }

    public class Query : MemorabiliaQuery, IQuery<PhotoViewModel>
    {
        public Query(int memorabiliaId) : base(memorabiliaId) { }
    }
}
