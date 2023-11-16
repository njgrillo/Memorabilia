namespace Memorabilia.Application.Features.Admin.Brands;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveBrand(DomainEditModel Brand) : ICommand
{
    public class Handler(IDomainRepository<Entity.Brand> brandRepository) 
        : CommandHandler<SaveBrand>
    {
        protected override async Task Handle(SaveBrand request)
        {
            Entity.Brand brand;

            if (request.Brand.IsNew)
            {
                brand = new Entity.Brand(request.Brand.Name, 
                                         request.Brand.Abbreviation);

                await brandRepository.Add(brand);

                return;
            }

            brand = await brandRepository.Get(request.Brand.Id);

            if (request.Brand.IsDeleted)
            {
                await brandRepository.Delete(brand);

                return;
            }

            brand.Set(request.Brand.Name, 
                      request.Brand.Abbreviation);

            await brandRepository.Update(brand);
        }
    }
}
