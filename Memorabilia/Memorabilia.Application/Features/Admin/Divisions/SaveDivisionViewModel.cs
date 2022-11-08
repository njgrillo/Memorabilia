using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Divisions;

public class SaveDivisionViewModel : SaveViewModel
{
    public SaveDivisionViewModel() { }

    public SaveDivisionViewModel(DivisionViewModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        ConferenceId = viewModel.ConferenceId ?? 0;
        Id = viewModel.Id;
        LeagueId = viewModel.LeagueId ?? 0;
        Name = viewModel.Name;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public int ConferenceId { get; set; }

    public Conference[] Conferences => Conference.All;

    public override string ExitNavigationPath => AdminDomainItem.Divisions.Page;

    public string ImageFileName => AdminDomainItem.Divisions.ImageFileName;

    public override string ItemTitle => AdminDomainItem.Divisions.Item;

    public int LeagueId { get; set; }

    public League[] Leagues => League.All;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public string Name { get; set; }

    public override string RoutePrefix => AdminDomainItem.Divisions.Page;
}
