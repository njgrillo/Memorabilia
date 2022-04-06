using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Orientations
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
                return new OrientationsViewModel(await _orientationRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<OrientationsViewModel> { }
    }
}
