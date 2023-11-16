namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public record GetChampionTypes() : IQuery<Entity.ChampionType[]>
{
    public class Handler(IDomainRepository<Entity.ChampionType> championTypeRepository) 
        : QueryHandler<GetChampionTypes, Entity.ChampionType[]>
    {
        protected override async Task<Entity.ChampionType[]> Handle(GetChampionTypes query)
            => await championTypeRepository.GetAll();
    }
}
