namespace Memorabilia.Application.Features.Admin.Colors;

public record GetColor(int Id) : IQuery<Entity.Color>
{
    public class Handler : QueryHandler<GetColor, Entity.Color>
    {
        private readonly IDomainRepository<Entity.Color> _colorRepository;

        public Handler(IDomainRepository<Entity.Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        protected override async Task<Entity.Color> Handle(GetColor query)
            => await _colorRepository.Get(query.Id);
    }
}
