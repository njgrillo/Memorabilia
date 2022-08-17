using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class TeamViewModel
    {
        private readonly Team _team;

        public TeamViewModel() { }

        public TeamViewModel(Team team)
        {
            _team = team;
        }

        public string Abbreviation => _team.Abbreviation;

        public int? BeginYear => _team.BeginYear;

        public string DisplayName => _team != null 
            ? $"Franchise: {_team.Franchise.FullName}, Team: {_team.Location} {_team.Name} ({_team.BeginYear} - {(_team.EndYear.HasValue ? _team.EndYear : "current")})"
            : string.Empty;

        public int? EndYear => _team.EndYear;

        public int FranchiseId => _team.FranchiseId;

        public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId).Name;

        public int Id => _team.Id;

        public string ImagePath => _team.ImagePath;

        public string Location => _team.Location;

        public string Name => _team.Name;

        public string Nickname => _team.Nickname;

        public int SportId => _team.Franchise.SportLeagueLevel.SportId;

        public Domain.Constants.SportLeagueLevel SportLeagueLevel => Domain.Constants.SportLeagueLevel.Find(_team.Franchise.SportLeagueLevelId);
    }
}
