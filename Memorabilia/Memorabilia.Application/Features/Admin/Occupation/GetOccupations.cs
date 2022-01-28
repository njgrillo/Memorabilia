using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Occupation
{
    public class GetOccupations
    {
        public class Handler : QueryHandler<Query, OccupationsViewModel>
        {
            private readonly IOccupationRepository _occupationRepository;

            public Handler(IOccupationRepository occupationRepository)
            {
                _occupationRepository = occupationRepository;
            }

            protected override async Task<OccupationsViewModel> Handle(Query query)
            {
                var occupations = await _occupationRepository.GetAll().ConfigureAwait(false);

                var viewModel = new OccupationsViewModel(occupations);

                return viewModel;
            }
        }

        public class Query : IQuery<OccupationsViewModel>
        {
        }
    }
}
