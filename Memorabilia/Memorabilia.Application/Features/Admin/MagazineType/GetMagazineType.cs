using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.MagazineType
{
    public class GetMagazineType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IMagazineTypeRepository _magazineTypeRepository;

            public Handler(IMagazineTypeRepository magazineTypeRepository)
            {
                _magazineTypeRepository = magazineTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var magazineType = await _magazineTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(magazineType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
