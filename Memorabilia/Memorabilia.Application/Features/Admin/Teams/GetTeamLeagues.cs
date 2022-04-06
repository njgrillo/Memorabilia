using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class GetTeamLeagues
    {
        public class Handler : QueryHandler<Query, IEnumerable<TeamLeagueViewModel>>
        {
            private readonly ITeamLeagueRepository _teamLeagueRepository;

            public Handler(ITeamLeagueRepository teamLeagueRepository)
            {
                _teamLeagueRepository = teamLeagueRepository;
            }

            protected override async Task<IEnumerable<TeamLeagueViewModel>> Handle(Query query)
            {
                var teamLeagues = await _teamLeagueRepository.GetAll(query.TeamId).ConfigureAwait(false);

                return teamLeagues.Select(teamLeague => new TeamLeagueViewModel(teamLeague));
            }
        }

        public class Query : IQuery<IEnumerable<TeamLeagueViewModel>>
        {
            public Query(int teamId)
            {
                TeamId = teamId;
            }

            public int TeamId { get; }
        }
    }
}
