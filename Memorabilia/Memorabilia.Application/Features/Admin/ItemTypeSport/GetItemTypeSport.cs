using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSport
{
    public class GetItemTypeSport
    {
        public class Handler : QueryHandler<Query, ItemTypeSportViewModel>
        {
            private readonly IItemTypeSportRepository _itemTypeSportRepository;

            public Handler(IItemTypeSportRepository itemTypeSportRepository)
            {
                _itemTypeSportRepository = itemTypeSportRepository;
            }

            protected override async Task<ItemTypeSportViewModel> Handle(Query query)
            {
                var itemTypeSport = await _itemTypeSportRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new ItemTypeSportViewModel(itemTypeSport);

                return viewModel;
            }
        }

        public class Query : IQuery<ItemTypeSportViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
