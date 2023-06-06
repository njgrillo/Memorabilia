using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public record GetItemType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetItemType, DomainModel>
    {
        private readonly IDomainRepository<ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetItemType query)
        {
            return new DomainModel(await _itemTypeRepository.Get(query.Id));
        }
    }
}
