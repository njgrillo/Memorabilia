namespace Memorabilia.Application.Features.Admin.Occupations;

public record GetOccupations() : IQuery<Entity.Occupation[]>
{
    public class Handler(IDomainRepository<Entity.Occupation> occupationRepository) 
        : QueryHandler<GetOccupations, Entity.Occupation[]>
    {
        protected override async Task<Entity.Occupation[]> Handle(GetOccupations query)
            => await occupationRepository.GetAll();
    }
}
