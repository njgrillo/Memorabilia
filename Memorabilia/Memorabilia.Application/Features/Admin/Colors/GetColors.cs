namespace Memorabilia.Application.Features.Admin.Colors;

public record GetColors() : IQuery<Entity.Color[]>
{
    public class Handler : QueryHandler<GetColors, Entity.Color[]>
    {
        private readonly IDomainRepository<Entity.Color> _colorRepository;

        public Handler(IDomainRepository<Entity.Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<Entity.Color[]> Handle(GetColors query)
            => (await _colorRepository.GetAll())
                    .ToArray();
    }
}
