namespace Memorabilia.Application.Features.Admin.Brands;

public record GetBrands() : IQuery<Entity.Brand[]>
{
    public class Handler : QueryHandler<GetBrands, Entity.Brand[]>
    {
        private readonly IDomainRepository<Entity.Brand> _brandRepository;

        public Handler(IDomainRepository<Entity.Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task<Entity.Brand[]> Handle(GetBrands query)
            => await _brandRepository.GetAll();
    }
}
