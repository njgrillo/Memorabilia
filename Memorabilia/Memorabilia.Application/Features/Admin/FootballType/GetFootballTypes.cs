using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FootballType
{
    public class GetFootballTypes
    {
        public class Handler : QueryHandler<Query, FootballTypesViewModel>
        {
            private readonly IFootballTypeRepository _footballTypeRepository;

            public Handler(IFootballTypeRepository footballTypeRepository)
            {
                _footballTypeRepository = footballTypeRepository;
            }

            protected override async Task<FootballTypesViewModel> Handle(Query query)
            {
                var footballTypes = await _footballTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new FootballTypesViewModel(footballTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<FootballTypesViewModel> { }
    }
}
