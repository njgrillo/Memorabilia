using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonTeamsViewModel : SaveViewModel
    {
        public SavePersonTeamsViewModel() { }

        public SavePersonTeamsViewModel(int personId, List<SavePersonTeamViewModel> teams)
        {
            PersonId = personId;
            Teams = teams;
        }

        public override string BackNavigationPath => $"People/Occupation/Edit/{PersonId}";

        public override string ContinueNavigationPath => $"People/HallOfFame/Edit/{PersonId}";

        public override EditModeType EditModeType => Teams.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Admin/EditDomainItems";

        public string ImagePath => "images/athletes.jpg";

        public override string ItemTitle => "Teams";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Teams";

        public int PersonId { get; set; }

        public PersonStep PersonStep => PersonStep.Team;

        public List<SavePersonTeamViewModel> Teams { get; set; } = new();
    }
}
