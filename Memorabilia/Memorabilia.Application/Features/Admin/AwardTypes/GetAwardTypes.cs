using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AwardTypes
{
    public class GetAwardTypes
    {
        public class Handler : QueryHandler<Query, AwardTypesViewModel>
        {
            private readonly IAwardTypeRepository _awardTypeRepository;

            public Handler(IAwardTypeRepository awardTypeRepository)
            {
                _awardTypeRepository = awardTypeRepository;
            }

            protected override async Task<AwardTypesViewModel> Handle(Query query)
            {
                return new AwardTypesViewModel(await _awardTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<AwardTypesViewModel> { }
    }
}
