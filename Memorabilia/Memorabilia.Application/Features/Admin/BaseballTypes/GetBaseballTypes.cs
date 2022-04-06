using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BaseballTypes
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
                return new BaseballTypesViewModel(await _baseballTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<BaseballTypesViewModel> { }
    }
}
