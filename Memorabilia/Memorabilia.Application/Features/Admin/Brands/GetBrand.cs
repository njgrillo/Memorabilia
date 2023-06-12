namespace Memorabilia.Application.Features.Admin.Brands;

public record GetBrand(int Id) : IQuery<Entity.Brand>
{
    public class Handler : QueryHandler<GetBrand, Entity.Brand>
    {
        private readonly IDomainRepository<Entity.Brand> _brandRepository;

        public Handler(IDomainRepository<Entity.Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task<Entity.Brand> Handle(GetBrand query)
            => await _brandRepository.Get(query.Id);
    }
}
