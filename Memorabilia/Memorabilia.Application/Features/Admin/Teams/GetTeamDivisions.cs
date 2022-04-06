using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class GetTeamDivisions
    {
        public class Handler : QueryHandler<Query, IEnumerable<TeamDivisionViewModel>>
        {
            private readonly ITeamDivisionRepository _teamDivisionRepository;

            public Handler(ITeamDivisionRepository teamDivisionRepository)
            {
                _teamDivisionRepository = teamDivisionRepository;
            }

            protected override async Task<IEnumerable<TeamDivisionViewModel>> Handle(Query query)
            {
                var teamDivisions = await _teamDivisionRepository.GetAll(query.TeamId).ConfigureAwait(false);

                return teamDivisions.Select(teamDivision => new TeamDivisionViewModel(teamDivision));
            }
        }

        public class Query : IQuery<IEnumerable<TeamDivisionViewModel>>
        {
            public Query(int teamId)
            {
                TeamId = teamId;
            }

            public int TeamId { get; }
        }
    }
}
