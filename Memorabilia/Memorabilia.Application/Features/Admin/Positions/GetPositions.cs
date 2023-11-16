namespace Memorabilia.Application.Features.Admin.Positions;

public record GetPositions() : IQuery<Entity.Position[]>
{
    public class Handler(IDomainRepository<Entity.Position> positionRepository) 
        : QueryHandler<GetPositions, Entity.Position[]>
    {
        protected override async Task<Entity.Position[]> Handle(GetPositions query)
            => await positionRepository.GetAll();
    }
}
