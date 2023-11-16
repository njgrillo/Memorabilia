namespace Memorabilia.Application.Features.Admin.Occupations;

public record GetOccupation(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.Occupation> occupationRepository) 
        : QueryHandler<GetOccupation, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetOccupation query)
            => await occupationRepository.Get(query.Id);
    }
}
