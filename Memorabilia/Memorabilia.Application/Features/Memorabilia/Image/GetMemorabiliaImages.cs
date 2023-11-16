namespace Memorabilia.Application.Features.Memorabilia.Image;

public record GetMemorabiliaImages(int MemorabiliaId) 
    : IQuery<Entity.MemorabiliaImage[]>
{
    public class Handler(IMemorabiliaImageRepository memorabiliaImageRepository) 
        : QueryHandler<GetMemorabiliaImages, Entity.MemorabiliaImage[]>
    {
        protected override async Task<Entity.MemorabiliaImage[]> Handle(GetMemorabiliaImages query)
            => await memorabiliaImageRepository.GetAll(query.MemorabiliaId);
    }
}
