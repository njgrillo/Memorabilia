namespace Memorabilia.Application.Features.Memorabilia.Image;

public record GetMemorabiliaImages(int MemorabiliaId) : IQuery<Entity.MemorabiliaImage[]>
{
    public class Handler : QueryHandler<GetMemorabiliaImages, Entity.MemorabiliaImage[]>
    {
        private readonly IMemorabiliaImageRepository _memorabiliaImageRepository;

        public Handler(IMemorabiliaImageRepository memorabiliaImageRepository)
        {
            _memorabiliaImageRepository = memorabiliaImageRepository;
        }

        protected override async Task<Entity.MemorabiliaImage[]> Handle(GetMemorabiliaImages query)
            => (await _memorabiliaImageRepository.GetAll(query.MemorabiliaId))
                    .ToArray();
    }
}
