namespace Memorabilia.Application.Features.Admin.Team
{
    public class TeamViewModel
    {
        private readonly Domain.Entities.Team _team;

        public TeamViewModel() { }

        public TeamViewModel(Domain.Entities.Team team)
        {
            _team = team;
        }

        public string Abbreviation => _team.Abbreviation;

        public int? BeginYear => _team.BeginYear;

        public string DisplayName => _team != null 
            ? $"Franchise: {_team.Franchise.FullName}, Team: {_team.Name} ({_team.BeginYear} - {(_team.EndYear.HasValue ? _team.EndYear : "current")})"
            : string.Empty;

        public int? EndYear => _team.EndYear;

        public int FranchiseId => _team.FranchiseId;

        public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId).Name;

        public int Id => _team.Id;

        public string ImagePath => _team.ImagePath;

        public string Location => _team.Location;

        public string Name => _team.Name;

        public string Nickname => _team.Nickname;
    }
}
