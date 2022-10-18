using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public record SaveItemTypeSize(SaveItemTypeSizeViewModel ViewModel) : ICommand
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
            ItemTypeSize itemTypeSize;

            if (request.ViewModel.IsNew)
            {
                itemTypeSize = new ItemTypeSize(request.ViewModel.ItemTypeId, request.ViewModel.SizeId);

                await _itemTypeSizeRepository.Add(itemTypeSize);

                return;
            }

            itemTypeSize = await _itemTypeSizeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _itemTypeSizeRepository.Delete(itemTypeSize);

                return;
            }

            itemTypeSize.Set(request.ViewModel.SizeId);

            await _itemTypeSizeRepository.Update(itemTypeSize);
        }
    }
}
