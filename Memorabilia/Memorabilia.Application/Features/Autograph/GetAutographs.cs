namespace Memorabilia.Application.Features.Autograph;

public record GetAutographs(int? MemorabiliaId = null)
    : IQuery<Entity.Autograph[]>
{
    public class Handler(IAutographRepository autographRepository) 
        : QueryHandler<GetAutographs, Entity.Autograph[]>
    {
        protected override async Task<Entity.Autograph[]> Handle(GetAutographs query)
            => await autographRepository.GetAll(query.MemorabiliaId);
    }
}
