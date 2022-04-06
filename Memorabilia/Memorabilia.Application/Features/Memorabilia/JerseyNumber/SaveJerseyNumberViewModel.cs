using Memorabilia.Application.Features.Admin.Sports;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber
{
    public class SaveJerseyNumberViewModel : SaveItemViewModel
    {
        public SaveJerseyNumberViewModel() { }

        public SaveJerseyNumberViewModel(JerseyNumberViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;

            if (viewModel.Sports.Any())
                Sport = new SaveSportViewModel(new SportViewModel(viewModel.Sports.First().Sport));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool HasSport => Sport.Id > 0;

        public bool HasTeam => Team.Id > 0;

        public override string ImagePath => "images/jerseynumber.jpg";

        public override ItemType ItemType => ItemType.JerseyNumber;

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.JerseyNumber.Name} Details";

        public SaveSportViewModel Sport { get; set; }

        public SaveTeamViewModel Team { get; set; }
    }
}
