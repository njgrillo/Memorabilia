using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamViewModel : SaveViewModel, IWithName
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

    public override string BackNavigationPath => AdminDomainItem.Teams.Page;

    public int? BeginYear { get; set; }

    public bool CanHaveConference => SportLeagueLevel.Find(SportLeagueLevelId) != SportLeagueLevel.MajorLeagueBaseball;

    public override string ContinueNavigationPath => $"{AdminDomainItem.Teams.Item}/{AdminDomainItem.Divisions.Item}/{EditModeType.Update.Name}/{Id}/{SportLeagueLevelId}";

    public bool DisplayFranchise => Id == 0;

    public string DisplayName { get; set; }

    public int? EndYear { get; set; }

    [Required]
    public int FranchiseId { get; set; }

    public Franchise[] Franchises { get; set; } = Franchise.GetAll(SportLeagueLevel.MajorLeagueBaseball);

    public string ImagePath => AdminDomainItem.Teams.ImagePath;

    public override string ItemTitle => AdminDomainItem.Teams.Item;

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

    public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.Find(SportLeagueLevelId);

    public int SportLeagueLevelId
    {
        get
        {
            return _sportLeagueLeveId;
        }
        set
        {
            _sportLeagueLeveId = value;
            Franchises = Franchise.GetAll(SportLeagueLevel.Find(value));
        }
    }

    public TeamStep TeamStep => TeamStep.Team;

    string IWithName.Name => DisplayName;
}
