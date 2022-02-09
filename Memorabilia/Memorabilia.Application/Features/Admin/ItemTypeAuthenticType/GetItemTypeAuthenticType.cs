using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeAuthenticType
{
    public class GetItemTypeAuthenticType
    {
        public class Handler : QueryHandler<Query, ItemTypeAuthenticTypeViewModel>
        {
            private readonly IItemTypeAuthenticTypeRepository _itemTypeAuthenticTypeRepository;

            public Handler(IItemTypeAuthenticTypeRepository itemTypeAuthenticTypeRepository)
            {
                _itemTypeAuthenticTypeRepository = itemTypeAuthenticTypeRepository;
            }

            protected override async Task<ItemTypeAuthenticTypeViewModel> Handle(Query query)
            {
                var itemTypeAuthenticType = await _itemTypeAuthenticTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new ItemTypeAuthenticTypeViewModel(itemTypeAuthenticType);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeAuthenticTypeViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
