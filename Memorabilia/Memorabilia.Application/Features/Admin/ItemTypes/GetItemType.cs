using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypes;

public class GetItemType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<ItemType> _itemTypeRepository;

        public Handler(IDomainRepository<ItemType> itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _itemTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
