using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonTeamsViewModel : SaveViewModel
{
    public SavePersonTeamsViewModel() { }

    public SavePersonTeamsViewModel(PersonTeamsViewModel viewModel)
    {
        PersonId = viewModel.PersonId;
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();
        Teams = viewModel.Teams
                         .Select(team => new SavePersonTeamViewModel(new PersonTeamViewModel(team)))
                         .OrderBy(team => team.BeginYear)
                         .ThenBy(team => team.TeamDisplayName)
                         .ToList();
    }

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/SportService/{EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath => $"{AdminDomainItem.People.Title}/Accolade/{EditModeType.Update.Name}/{PersonId}";

    public override EditModeType EditModeType => Teams.Any() ? EditModeType.Update : EditModeType.Add;

    public string ImagePath => Domain.Constants.ImagePath.Athletes;

    public override string ItemTitle => AdminDomainItem.Teams.Title;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {ItemTitle}";

    public int PersonId { get; set; }

    public PersonStep PersonStep => PersonStep.Team;

    public List<int> SportIds { get; set; } = new();

    public List<SavePersonTeamViewModel> Teams { get; set; } = new();
}
