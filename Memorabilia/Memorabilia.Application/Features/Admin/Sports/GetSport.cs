namespace Memorabilia.Application.Features.Admin.Sports;

public record GetSport(int Id) : IQuery<Entity.Sport>
{
    public class Handler(IDomainRepository<Entity.Sport> sportRepository) 
        : QueryHandler<GetSport, Entity.Sport>
    {
        protected override async Task<Entity.Sport> Handle(GetSport query)
            => await sportRepository.Get(query.Id);
    }
}
