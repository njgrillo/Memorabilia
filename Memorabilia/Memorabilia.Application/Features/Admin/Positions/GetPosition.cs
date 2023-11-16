namespace Memorabilia.Application.Features.Admin.Positions;

public record GetPosition(int Id) : IQuery<Entity.Position>
{
    public class Handler(IDomainRepository<Entity.Position> positionRepository) 
        : QueryHandler<GetPosition, Entity.Position>
    {
        protected override async Task<Entity.Position> Handle(GetPosition query)
            => await positionRepository.Get(query.Id);
    }
}
