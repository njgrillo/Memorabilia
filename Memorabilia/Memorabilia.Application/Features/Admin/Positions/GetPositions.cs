namespace Memorabilia.Application.Features.Admin.Positions;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetPositions() : IQuery<Entity.Position[]>
{
    public class Handler : QueryHandler<GetPositions, Entity.Position[]>
    {
        private readonly IDomainRepository<Entity.Position> _positionRepository;

        public Handler(IDomainRepository<Entity.Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        protected override async Task<Entity.Position[]> Handle(GetPositions query)
            => await _positionRepository.GetAll();
    }
}
