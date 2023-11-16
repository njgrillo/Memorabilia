namespace Memorabilia.Application.Features.Admin.Divisions;

public record GetDivision(int Id) : IQuery<Entity.Division>
{
    public class Handler(IDomainRepository<Entity.Division> divisionRepository) 
        : QueryHandler<GetDivision, Entity.Division>
    {
        protected override async Task<Entity.Division> Handle(GetDivision query)
            => await divisionRepository.Get(query.Id);
    }
}
