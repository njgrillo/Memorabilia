namespace Memorabilia.Application.Features.Admin.Brands;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBrand(DomainEditModel Brand) : ICommand
{
    public class Handler : CommandHandler<SaveBrand>
    {
        private readonly IDomainRepository<Entity.Brand> _brandRepository;

        public Handler(IDomainRepository<Entity.Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        protected override async Task Handle(SaveBrand request)
        {
            Entity.Brand brand;

            if (request.Brand.IsNew)
            {
                brand = new Entity.Brand(request.Brand.Name, 
                                         request.Brand.Abbreviation);

                await _brandRepository.Add(brand);

                return;
            }

            brand = await _brandRepository.Get(request.Brand.Id);

            if (request.Brand.IsDeleted)
            {
                await _brandRepository.Delete(brand);

                return;
            }

            brand.Set(request.Brand.Name, 
                      request.Brand.Abbreviation);

            await _brandRepository.Update(brand);
        }
    }
}
