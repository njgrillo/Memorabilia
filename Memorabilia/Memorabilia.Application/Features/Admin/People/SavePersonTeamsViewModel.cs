using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
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

        public override string BackNavigationPath => $"People/SportService/Edit/{PersonId}";

        public override string ContinueNavigationPath => $"People/Accolade/Edit/{PersonId}";

        public override EditModeType EditModeType => Teams.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Admin/EditDomainItems";

        public string ImagePath => "images/athletes.jpg";

        public override string ItemTitle => "Teams";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Teams";

        public int PersonId { get; set; }

        public PersonStep PersonStep => PersonStep.Team;

        public List<int> SportIds { get; set; } = new();

        public List<SavePersonTeamViewModel> Teams { get; set; } = new();
    }
}
