namespace Memorabilia.Application.Features.Autograph.Image;

public record GetAutographImages(int AutographId) : IQuery<Entity.AutographImage[]>
{
    public class Handler : QueryHandler<GetAutographImages, Entity.AutographImage[]>
    {
        private readonly IAutographImageRepository _autographImageRepository;

        public Handler(IAutographImageRepository AutographImageRepository)
        {
            _autographImageRepository = AutographImageRepository;
        }

        protected override async Task<Entity.AutographImage[]> Handle(GetAutographImages query)
            => (await _autographImageRepository.GetAll(query.AutographId))
                    .ToArray();
    }
}
