using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public class SaveLeaguePresidentViewModel : EditModel
{
    public SaveLeaguePresidentViewModel() { }

    public SaveLeaguePresidentViewModel(LeaguePresidentViewModel viewModel)
    {
        BeginYear = viewModel.BeginYear;
        EndYear = viewModel.EndYear;
        Id = viewModel.Id;
        LeagueId = viewModel.LeagueId;
        Person = new PersonViewModel(viewModel.Person);
        SportLeagueLevelId = viewModel.SportLeagueLevelId;
    }

    public int? BeginYear { get; set; }

    public int? EndYear { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.LeaguePresidents.Page;

    public string ImageFileName => AdminDomainItem.LeaguePresidents.ImageFileName;

    public override string ItemTitle => AdminDomainItem.LeaguePresidents.Item;

    [Required]
    public int LeagueId { get; set; }

    [Required]
    public PersonViewModel Person { get; set; }

    public override string RoutePrefix => AdminDomainItem.LeaguePresidents.Page;

    public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.Find(SportLeagueLevelId);

    [Required]
    public int SportLeagueLevelId { get; set; }
}
