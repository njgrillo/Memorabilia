namespace Memorabilia.Application.Features.Autograph.Spot;

public record GetSpot(int AutographId)
    : IQuery<Entity.Autograph>
{
    public class Handler(IAutographRepository autographRepository) 
        : QueryHandler<GetSpot, Entity.Autograph>
    {
        protected override async Task<Entity.Autograph> Handle(GetSpot query)
            => await autographRepository.Get(query.AutographId);
    }
}
