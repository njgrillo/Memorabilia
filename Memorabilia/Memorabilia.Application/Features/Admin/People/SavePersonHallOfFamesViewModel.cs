using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonHallOfFamesViewModel : SaveViewModel
    {
        public SavePersonHallOfFamesViewModel() { }

        public SavePersonHallOfFamesViewModel(int personId, List<SavePersonHallOfFameViewModel> hallOfFames)
        {
            PersonId = personId;
            HallOfFames = hallOfFames;
        }

        public override string BackNavigationPath => $"People/Team/Edit/{PersonId}";

        public override string ContinueNavigationPath => $"People/Image/Edit/{PersonId}";

        public override EditModeType EditModeType => HallOfFames.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => $"Admin/EditDomainItems";

        public List<SavePersonHallOfFameViewModel> HallOfFames { get; set; } = new();

        public string ImagePath => "images/athletes.jpg";

        public override string ItemTitle => "Hall of Fame";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Hall of Fame";

        public int PersonId { get; set; }

        public PersonStep PersonStep => PersonStep.HallOfFame;
    }
}
