using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes
{
    public class GetInternationalHallOfFameType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IInternationalHallOfFameTypeRepository _internationalHallOfFameTypeRepository;

            public Handler(IInternationalHallOfFameTypeRepository internationalHallOfFameTypeRepository)
            {
                _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _internationalHallOfFameTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
