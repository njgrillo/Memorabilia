using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.MagazineTypes
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
                return new MagazineTypesViewModel(await _magazineTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<MagazineTypesViewModel> { }
    }
}
