using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes
{
    public class GetHelmetQualityType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IHelmetQualityTypeRepository _helmetQualityTypeRepository;

            public Handler(IHelmetQualityTypeRepository helmetQualityTypeRepository)
            {
                _helmetQualityTypeRepository = helmetQualityTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _helmetQualityTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
