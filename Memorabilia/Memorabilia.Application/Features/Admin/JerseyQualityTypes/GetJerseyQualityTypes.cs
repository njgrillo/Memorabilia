using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes
{
    public class GetJerseyQualityTypes
    {
        public class Handler : QueryHandler<Query, JerseyQualityTypesViewModel>
        {
            private readonly IJerseyQualityTypeRepository _jerseyQualityTypeRepository;

            public Handler(IJerseyQualityTypeRepository jerseyQualityTypeRepository)
            {
                _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
            }

            protected override async Task<JerseyQualityTypesViewModel> Handle(Query query)
            {
                return new JerseyQualityTypesViewModel(await _jerseyQualityTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<JerseyQualityTypesViewModel> { }
    }
}
