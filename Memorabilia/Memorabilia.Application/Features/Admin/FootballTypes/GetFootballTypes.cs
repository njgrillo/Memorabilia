namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record GetFootballTypes() : IQuery<Entity.FootballType[]>
{
    public class Handler(IDomainRepository<Entity.FootballType> footballTypeRepository) 
        : QueryHandler<GetFootballTypes, Entity.FootballType[]>
    {
        protected override async Task<Entity.FootballType[]> Handle(GetFootballTypes query)
            => await footballTypeRepository.GetAll();
    }
}
