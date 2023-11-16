namespace Memorabilia.Application.Features.Admin.Divisions;

public record GetDivisions() : IQuery<Entity.Division[]>
{
    public class Handler(IDomainRepository<Entity.Division> divisionRepository) 
        : QueryHandler<GetDivisions, Entity.Division[]>
    {
        protected override async Task<Entity.Division[]> Handle(GetDivisions query)
            => await divisionRepository.GetAll();
    }
}
