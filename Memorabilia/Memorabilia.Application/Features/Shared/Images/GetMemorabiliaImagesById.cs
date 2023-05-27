namespace Memorabilia.Application.Features.Shared.Images;

public record GetMemorabiliaImagesById(int MemorabiliaId) : IQuery<Domain.Entities.MemorabiliaImage[]>
{
    public class Handler : QueryHandler<GetMemorabiliaImagesById, Domain.Entities.MemorabiliaImage[]>
    {
        private readonly IMemorabiliaImageRepository _memorabiliaImageRepository;

        public Handler(IMemorabiliaImageRepository memorabiliaImageRepository)
        {
            _memorabiliaImageRepository = memorabiliaImageRepository;
        }

        protected override async Task<Domain.Entities.MemorabiliaImage[]> Handle(GetMemorabiliaImagesById query)
        {
            return (await _memorabiliaImageRepository.GetAll(query.MemorabiliaId)).ToArray();
        }
    }
}
