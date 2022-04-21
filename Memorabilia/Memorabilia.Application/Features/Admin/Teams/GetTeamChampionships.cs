using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class GetTeamChampionships
    {
        public class Handler : QueryHandler<Query, IEnumerable<TeamChampionshipViewModel>>
        {
            private readonly ITeamChampionshipRepository _teamChampionshipRepository;

            public Handler(ITeamChampionshipRepository teamChampionshipRepository)
            {
                _teamChampionshipRepository = teamChampionshipRepository;
            }

            protected override async Task<IEnumerable<TeamChampionshipViewModel>> Handle(Query query)
            {
                var teamChampionships = await _teamChampionshipRepository.GetAll(query.TeamId).ConfigureAwait(false);

                return teamChampionships.Select(teamChampionship => new TeamChampionshipViewModel(teamChampionship));
            }
        }

        public class Query : IQuery<IEnumerable<TeamChampionshipViewModel>>
        {
            public Query(int teamId)
            {
                TeamId = teamId;
            }

            public int TeamId { get; }
        }
    }
}
