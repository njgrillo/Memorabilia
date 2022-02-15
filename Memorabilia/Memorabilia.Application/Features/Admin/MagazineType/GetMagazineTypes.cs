using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.MagazineType
{
    public class GetMagazineTypes
    {
        public class Handler : QueryHandler<Query, MagazineTypesViewModel>
        {
            private readonly IMagazineTypeRepository _magazineTypeRepository;

            public Handler(IMagazineTypeRepository magazineTypeRepository)
            {
                _magazineTypeRepository = magazineTypeRepository;
            }

            protected override async Task<MagazineTypesViewModel> Handle(Query query)
            {
                var magazineTypes = await _magazineTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new MagazineTypesViewModel(magazineTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<MagazineTypesViewModel> { }
    }
}
