namespace Memorabilia.Application.Features.Admin.Brands;

public record GetBrands() : IQuery<Entity.Brand[]>
{
    public class Handler(IDomainRepository<Entity.Brand> brandRepository) 
        : QueryHandler<GetBrands, Entity.Brand[]>
    {
        protected override async Task<Entity.Brand[]> Handle(GetBrands query)
            => await brandRepository.GetAll();
    }
}
