namespace Memorabilia.Application.Features.Admin.Franchises;

public record GetFranchises() : IQuery<Entity.Franchise[]>
{
    public class Handler(IDomainRepository<Entity.Franchise> franchiseRepository) 
        : QueryHandler<GetFranchises, Entity.Franchise[]>
    {
        protected override async Task<Entity.Franchise[]> Handle(GetFranchises query)
            => await franchiseRepository.GetAll();
    }
}
