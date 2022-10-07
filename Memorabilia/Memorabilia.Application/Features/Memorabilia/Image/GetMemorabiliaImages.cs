namespace Memorabilia.Application.Features.Memorabilia.Image;

public class GetMemorabiliaImages
{
    public class Handler : QueryHandler<Query, MemorabiliaImagesViewModel>
    {
        private readonly IMemorabiliaImageRepository _memorabiliaImageRepository;

        public Handler(IMemorabiliaImageRepository memorabiliaImageRepository)
        {
            _memorabiliaImageRepository = memorabiliaImageRepository;
        }

        protected override async Task<MemorabiliaImagesViewModel> Handle(Query query)
        {
            return new MemorabiliaImagesViewModel(await _memorabiliaImageRepository.GetAll(query.MemorabiliaId));
        }
    }

    public class Query : IQuery<MemorabiliaImagesViewModel> 
    {
        public Query(int memorabiliaId)
        {
            MemorabiliaId = memorabiliaId;
        }

        public int MemorabiliaId { get; }
    }
}
