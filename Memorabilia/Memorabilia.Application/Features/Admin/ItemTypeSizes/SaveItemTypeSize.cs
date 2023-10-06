namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveItemTypeSize(ItemTypeSizeEditModel ItemTypeSize) : ICommand
{
    public class Handler : CommandHandler<SaveItemTypeSize>
    {
        private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

        public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
        {
            _itemTypeSizeRepository = itemTypeSizeRepository;
        }

        protected override async Task Handle(SaveItemTypeSize request)
        {
            Entity.ItemTypeSize itemTypeSize;

            if (request.ItemTypeSize.IsNew)
            {
                itemTypeSize = new Entity.ItemTypeSize(request.ItemTypeSize.ItemType.Id, 
                                                       request.ItemTypeSize.Size.Id);

                await _itemTypeSizeRepository.Add(itemTypeSize);

                return;
            }

            itemTypeSize = await _itemTypeSizeRepository.Get(request.ItemTypeSize.Id);

            if (request.ItemTypeSize.IsDeleted)
            {
                await _itemTypeSizeRepository.Delete(itemTypeSize);

                return;
            }

            itemTypeSize.Set(request.ItemTypeSize.Size.Id);

            await _itemTypeSizeRepository.Update(itemTypeSize);
        }
    }
}
