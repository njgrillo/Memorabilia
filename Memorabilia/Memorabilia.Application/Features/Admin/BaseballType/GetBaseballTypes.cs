using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BaseballType
{
    public class GetBaseballTypes
    {
        public class Handler : QueryHandler<Query, BaseballTypesViewModel>
        {
            private readonly IBaseballTypeRepository _baseballTypeRepository;

            public Handler(IBaseballTypeRepository baseballTypeRepository)
            {
                _baseballTypeRepository = baseballTypeRepository;
            }

            protected override async Task<BaseballTypesViewModel> Handle(Query query)
            {
                var baseballTypes = await _baseballTypeRepository.GetAll().ConfigureAwait(false);

                return new BaseballTypesViewModel(baseballTypes);
            }
        }

        public class Query : IQuery<BaseballTypesViewModel> { }
    }
}
