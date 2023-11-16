namespace Memorabilia.Application.Features.Admin.Pewters;

public record GetPewters() : IQuery<Entity.Pewter[]>
{
    public class Handler(IDomainRepository<Entity.Pewter> pewterRepository) 
        : QueryHandler<GetPewters, Entity.Pewter[]>
    {
        protected override async Task<Entity.Pewter[]> Handle(GetPewters query)
            => (await pewterRepository.GetAll())
                    .OrderBy(pewter => pewter.FranchiseName)
                    .ThenBy(pewter => pewter.Team.Name)
                    .ThenBy(pewter => pewter.SizeName)
                    .ThenBy(pewter => pewter.ImageTypeName)
                    .ToArray();
    }
}
