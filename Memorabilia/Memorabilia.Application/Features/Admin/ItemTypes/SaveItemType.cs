using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record SaveItemType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveItemType>
    {
        private readonly IDomainRepository<ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task Handle(SaveItemType request)
        {
            ItemType itemType;

            if (request.ViewModel.IsNew)
            {
                itemType = new ItemType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _itemTypeRepository.Add(itemType);

                return;
            }

            itemType = await _itemTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _itemTypeRepository.Delete(itemType);

                return;
            }

            itemType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _itemTypeRepository.Update(itemType);
        }
    }
}
