namespace Memorabilia.Application.Features.Admin.Positions;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetPosition(int Id) : IQuery<Entity.Position>
{
    public class Handler : QueryHandler<GetPosition, Entity.Position>
    {
        private readonly IDomainRepository<Entity.Position> _positionRepository;

        public Handler(IDomainRepository<Entity.Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        protected override async Task<Entity.Position> Handle(GetPosition query)
            => await _positionRepository.Get(query.Id);
    }
}
