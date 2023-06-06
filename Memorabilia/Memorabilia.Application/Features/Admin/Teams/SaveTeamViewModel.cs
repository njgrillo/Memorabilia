using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamViewModel : EditModel, IWithName, IWithValue<int>
{
    public SaveTeamViewModel() { }

    public SaveTeamViewModel(TeamViewModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        BeginYear = viewModel.BeginYear;
        DisplayName = viewModel.DisplayName;
        EndYear = viewModel.EndYear;
        Franchise = Franchise.Find(viewModel.FranchiseId);
        Id = viewModel.Id;
        Location = viewModel.Location;
        Name = viewModel.Name;
        Nickname = viewModel.Nickname;
        SportLeagueLevelId = viewModel.SportLeagueLevel.Id;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string BackNavigationPath => AdminDomainItem.Teams.Page;

    public int? BeginYear { get; set; }

    public bool CanHaveConference => SportLeagueLevel.Find(SportLeagueLevelId) != SportLeagueLevel.MajorLeagueBaseball;

    public override string ContinueNavigationPath => $"{AdminDomainItem.Teams.Item}/{AdminDomainItem.Divisions.Item}/{EditModeType.Update.Name}/{Id}/{SportLeagueLevelId}";

    public bool DisplayFranchise => Id == 0;

    public string DisplayName { get; set; }

    public int? EndYear { get; set; }

    public Franchise Franchise { get; set; }

    public string ImageFileName => AdminDomainItem.Teams.ImageFileName;

    public override string ItemTitle => AdminDomainItem.Teams.Item;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public string Location { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    [StringLength(10, ErrorMessage = "Nickname is too long.")]
    public string Nickname { get; set; }

    public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.Find(SportLeagueLevelId);

    public int SportLeagueLevelId { get; set; }

    public Sport[] Sports => SportLeagueLevel != null 
        ? new[] { SportLeagueLevel.Sport }
        : Array.Empty<Sport>();

    public TeamStep TeamStep => TeamStep.Team;

    string IWithName.Name => DisplayName;

    int IWithValue<int>.Value => Id;
}
