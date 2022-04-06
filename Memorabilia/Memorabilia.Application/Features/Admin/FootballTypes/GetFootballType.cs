using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FootballTypes
{
    public class GetFootballType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IFootballTypeRepository _footballTypeRepository;

            public Handler(IFootballTypeRepository footballTypeRepository)
            {
                _footballTypeRepository = footballTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _footballTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
