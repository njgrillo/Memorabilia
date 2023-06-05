namespace Memorabilia.Application.Features.Autograph.Spot;

public record GetSpot(int AutographId)
    : IQuery<Entity.Autograph>
{
    public class Handler : QueryHandler<GetSpot, Entity.Autograph>
    {
        private readonly IAutographRepository _autographRepository;

        public Handler(IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
        }

        protected override async Task<Entity.Autograph> Handle(GetSpot query)
        {
            return await _autographRepository.Get(query.AutographId);
        }
    }
}
