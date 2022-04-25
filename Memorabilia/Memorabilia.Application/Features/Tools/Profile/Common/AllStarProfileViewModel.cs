using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class AllStarProfileViewModel
    {
        private readonly AllStar _allStar;
        private readonly PersonTeam _team;

        public AllStarProfileViewModel(AllStar allStar, PersonTeam team)
        {
            _allStar = allStar;
            _team = team;
        }

        public string TeamName => _team != null
            ? $"{_team.Team.Location} {_team.Team.Name}"
            : string.Empty;

        public int Year => _allStar.Year;
    }
}
