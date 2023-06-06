namespace Memorabilia.Application.Features.Shared.Images;

public record GetMemorabiliaImagesById(int MemorabiliaId) : IQuery<Entity.MemorabiliaImage[]>
{
    public class Handler : QueryHandler<GetMemorabiliaImagesById, Entity.MemorabiliaImage[]>
    {
        private readonly IMemorabiliaImageRepository _memorabiliaImageRepository;

        public Handler(IMemorabiliaImageRepository memorabiliaImageRepository)
        {
            _memorabiliaImageRepository = memorabiliaImageRepository;
        }

        protected override async Task<Entity.MemorabiliaImage[]> Handle(GetMemorabiliaImagesById query)
        {
            return (await _memorabiliaImageRepository.GetAll(query.MemorabiliaId)).ToArray();
        }
    }
}
