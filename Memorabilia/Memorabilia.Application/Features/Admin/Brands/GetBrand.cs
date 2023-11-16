namespace Memorabilia.Application.Features.Admin.Brands;

public record GetBrand(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.Brand> brandRepository) 
        : QueryHandler<GetBrand, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetBrand query)
            => await brandRepository.Get(query.Id);
    }
}
