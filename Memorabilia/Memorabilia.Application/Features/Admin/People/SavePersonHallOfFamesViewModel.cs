using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonHallOfFamesViewModel : SaveViewModel
    {
        public SavePersonHallOfFamesViewModel() { }

        public SavePersonHallOfFamesViewModel(int personId, PersonHallOfFameViewModel viewModel)
        {
            PersonId = personId;
            FranchiseHallOfFames = viewModel.FranchiseHallOfFames.Select(hof => new SavePersonFranchiseHallOfFameViewModel(hof)).ToList();
            HallOfFames = viewModel.HallOfFames.Select(hof => new SavePersonHallOfFameViewModel(hof)).ToList();
        }

        public override string BackNavigationPath => $"People/Accolade/Edit/{PersonId}";

        public override string ContinueNavigationPath => $"People/Image/Edit/{PersonId}";

        public override EditModeType EditModeType => HallOfFames.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => $"Admin/EditDomainItems";

        public List<SavePersonFranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = new();

        public List<SavePersonHallOfFameViewModel> HallOfFames { get; set; } = new();

        public string ImagePath => "images/athletes.jpg";

        public override string ItemTitle => "Hall of Fames";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Hall of Fames";

        public int PersonId { get; set; }

        public PersonStep PersonStep => PersonStep.HallOfFame;
    }
}
