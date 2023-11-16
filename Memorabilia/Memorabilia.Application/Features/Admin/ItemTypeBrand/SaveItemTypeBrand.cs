namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeBrand(ItemTypeBrandEditModel ItemTypeBrand) : ICommand
{
    public class Handler(IItemTypeBrandRepository itemTypeBrandRepository) 
        : CommandHandler<SaveItemTypeBrand>
    {
        protected override async Task Handle(SaveItemTypeBrand request)
        {
            Entity.ItemTypeBrand itemTypeBrand;

            if (request.ItemTypeBrand.IsNew)
            {
                itemTypeBrand = new Entity.ItemTypeBrand(request.ItemTypeBrand.ItemType.Id, 
                                                         request.ItemTypeBrand.Brand.Id);

                await itemTypeBrandRepository.Add(itemTypeBrand);

                return;
            }

            itemTypeBrand = await itemTypeBrandRepository.Get(request.ItemTypeBrand.Id);

            if (request.ItemTypeBrand.IsDeleted)
            {
                await itemTypeBrandRepository.Delete(itemTypeBrand);

                return;
            }

            itemTypeBrand.Set(request.ItemTypeBrand.Brand.Id);

            await itemTypeBrandRepository.Update(itemTypeBrand);
        }
    }
}
