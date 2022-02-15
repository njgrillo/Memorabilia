using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Orientation
{
    public class GetOrientation
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IOrientationRepository _orientationRepository;

            public Handler(IOrientationRepository orientationRepository)
            {
                _orientationRepository = orientationRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var orientation = await _orientationRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(orientation);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
