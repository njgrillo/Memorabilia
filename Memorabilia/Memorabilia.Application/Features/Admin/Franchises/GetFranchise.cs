namespace Memorabilia.Application.Features.Admin.Franchises;

public record GetFranchise(int Id) : IQuery<Entity.Franchise>
{
    public class Handler(IDomainRepository<Entity.Franchise> franchiseRepository) 
        : QueryHandler<GetFranchise, Entity.Franchise>
    {
        protected override async Task<Entity.Franchise> Handle(GetFranchise query)
            => await franchiseRepository.Get(query.Id);
    }
}
