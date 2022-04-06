using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypes
{
    public class GetItemTypes
    {
        public class Handler : QueryHandler<Query, ItemTypesViewModel>
        {
            private readonly IItemTypeRepository _itemTypeRepository;

            public Handler(IItemTypeRepository itemTypeRepository)
            {
                _itemTypeRepository = itemTypeRepository;
            }

            protected override async Task<ItemTypesViewModel> Handle(Query query)
            {
                return new ItemTypesViewModel(await _itemTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypesViewModel> { }
    }
}
