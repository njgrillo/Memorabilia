using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AwardTypes
{
    public class GetAwardType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IAwardTypeRepository _awardTypeRepository;

            public Handler(IAwardTypeRepository awardTypeRepository)
            {
                _awardTypeRepository = awardTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _awardTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
