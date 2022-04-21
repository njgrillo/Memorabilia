using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.LeaderTypes
{
    public class GetLeaderType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly ILeaderTypeRepository _leaderTypeRepository;

            public Handler(ILeaderTypeRepository leaderTypeRepository)
            {
                _leaderTypeRepository = leaderTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _leaderTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
