using Memorabilia.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class SaveTeamViewModel : SaveViewModel
    {
        public SaveTeamViewModel() { }

        public SaveTeamViewModel(TeamViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            BeginYear = viewModel.BeginYear;
            DisplayName = viewModel.DisplayName;
            EndYear = viewModel.EndYear;
            FranchiseId = viewModel.FranchiseId;
            Id = viewModel.Id;
            Location = viewModel.Location;
            Name = viewModel.Name;
            Nickname = viewModel.Nickname;
            SportLeagueLevelId = viewModel.SportLeagueLevel.Id;
        }

        private int _sportLeagueLeveId;

        [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
        public string Abbreviation { get; set; }

        public override string BackNavigationPath => "Teams";

        public int? BeginYear { get; set; }

        public bool CanHaveConference => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId) != Domain.Constants.SportLeagueLevel.MajorLeagueBaseball;

        public override string ContinueNavigationPath => $"Team/Division/Edit/{Id}/{SportLeagueLevelId}";

        public bool DisplayFranchise => Id == 0;

        public string DisplayName { get; set; }

        public EditModeType EditMode => Id > 0 ? EditModeType.Update : EditModeType.Add;

        public int? EndYear { get; set; }

        public override string ExitNavigationPath => "Admin/EditDomainItems";

        [Required]
        public int FranchiseId { get; set; }

        public Franchise[] Franchises { get; set; } = Franchise.GetFranchises(Domain.Constants.SportLeagueLevel.MajorLeagueBaseball);

        public string ImagePath => "images/teams.jpg";

        public override string ItemTitle => "Team";

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Location { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "Nickname is too long.")]
        public string Nickname { get; set; }

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Team";

        public Domain.Constants.SportLeagueLevel SportLeagueLevel => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId);

        public int SportLeagueLevelId
        {
            get
            {
                return _sportLeagueLeveId;
            }
            set
            {
                _sportLeagueLeveId = value;
                Franchises = Franchise.GetFranchises(Domain.Constants.SportLeagueLevel.Find(value));
            }
        }

        public TeamStep TeamStep => TeamStep.Team;
    }
}
