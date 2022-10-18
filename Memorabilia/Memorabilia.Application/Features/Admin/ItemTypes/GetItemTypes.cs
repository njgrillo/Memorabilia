using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record GetItemTypes() : IQuery<ItemTypesViewModel>
{
    public class Handler : QueryHandler<GetItemTypes, ItemTypesViewModel>
    {
        private readonly IDomainRepository<ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<ItemTypesViewModel> Handle(GetItemTypes query)
        {
            return new ItemTypesViewModel(await _itemTypeRepository.GetAll());
        }
    }
}
