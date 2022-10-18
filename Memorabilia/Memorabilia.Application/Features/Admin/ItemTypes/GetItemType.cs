using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record GetItemType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetItemType, DomainViewModel>
    {
        private readonly IDomainRepository<ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetItemType query)
        {
            return new DomainViewModel(await _itemTypeRepository.Get(query.Id));
        }
    }
}
