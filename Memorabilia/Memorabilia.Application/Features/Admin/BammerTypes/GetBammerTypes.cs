using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BammerTypes
{
    public class GetBammerTypes
    {
        public class Handler : QueryHandler<Query, BammerTypesViewModel>
        {
            private readonly IBammerTypeRepository _bammerTypeRepository;

            public Handler(IBammerTypeRepository bammerTypeRepository)
            {
                _bammerTypeRepository = bammerTypeRepository;
            }

            protected override async Task<BammerTypesViewModel> Handle(Query query)
            {
                return new BammerTypesViewModel(await _bammerTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<BammerTypesViewModel> { }
    }
}
