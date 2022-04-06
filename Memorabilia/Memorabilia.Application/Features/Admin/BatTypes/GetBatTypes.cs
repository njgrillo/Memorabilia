using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BatTypes
{
    public class GetBatTypes
    {
        public class Handler : QueryHandler<Query, BatTypesViewModel>
        {
            private readonly IBatTypeRepository _batTypeRepository;

            public Handler(IBatTypeRepository batTypeRepository)
            {
                _batTypeRepository = batTypeRepository;
            }

            protected override async Task<BatTypesViewModel> Handle(Query query)
            {
                return new BatTypesViewModel(await _batTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<BatTypesViewModel> { }
    }
}
