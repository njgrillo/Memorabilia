using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetFinish
{
    public class GetHelmetFinish
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IHelmetFinishRepository _helmetFinishRepository;

            public Handler(IHelmetFinishRepository helmetFinishRepository)
            {
                _helmetFinishRepository = helmetFinishRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var helmetFinish = await _helmetFinishRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(helmetFinish);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
