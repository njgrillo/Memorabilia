using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Orientation
{
    public class GetOrientations
    {
        public class Handler : QueryHandler<Query, OrientationsViewModel>
        {
            private readonly IOrientationRepository _orientationRepository;

            public Handler(IOrientationRepository orientationRepository)
            {
                _orientationRepository = orientationRepository;
            }

            protected override async Task<OrientationsViewModel> Handle(Query query)
            {
                var orientations = await _orientationRepository.GetAll().ConfigureAwait(false);

                var viewModel = new OrientationsViewModel(orientations);

                return viewModel;
            }
        }

        public class Query : IQuery<OrientationsViewModel> { }
    }
}
