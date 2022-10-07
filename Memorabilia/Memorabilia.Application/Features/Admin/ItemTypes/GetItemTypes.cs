using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public class GetItemTypes
{
    public class Handler : QueryHandler<Query, ItemTypesViewModel>
    {
        private readonly IDomainRepository<ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<ItemTypesViewModel> Handle(Query query)
        {
            return new ItemTypesViewModel(await _itemTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<ItemTypesViewModel> { }
}
