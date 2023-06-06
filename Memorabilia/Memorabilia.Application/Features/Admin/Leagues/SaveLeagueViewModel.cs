using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Leagues;

public class SaveLeagueViewModel : EditModel
{
    public SaveLeagueViewModel() { }

    public SaveLeagueViewModel(LeagueViewModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        Id = viewModel.Id;
        Name = viewModel.Name;
        SportLeagueLevelId = viewModel.SportLeagueLevelId;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.Leagues.Page;

    public string ImageFileName => AdminDomainItem.Leagues.ImageFileName;

    public override string ItemTitle => AdminDomainItem.Leagues.Item;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix => AdminDomainItem.Leagues.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport League Level is required.")]
    public int SportLeagueLevelId { get; set; }
}
