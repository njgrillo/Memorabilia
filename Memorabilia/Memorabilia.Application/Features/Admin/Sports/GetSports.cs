namespace Memorabilia.Application.Features.Admin.Sports;

public record GetSports() : IQuery<Entity.Sport[]>
{
    public class Handler(IDomainRepository<Entity.Sport> sportRepository) 
        : QueryHandler<GetSports, Entity.Sport[]>
    {
        protected override async Task<Entity.Sport[]> Handle(GetSports query)
            => (await sportRepository.GetAll())
                    .OrderBy(sport => sport.Name)
                    .ToArray();
    }
}
