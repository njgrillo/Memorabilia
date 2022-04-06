using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonOccupationsViewModel : SaveViewModel
    {
        public SavePersonOccupationsViewModel() { }

        public SavePersonOccupationsViewModel(int personId, List<SavePersonOccupationViewModel> personOccupations)
        {
            PersonId = personId;
            PersonOccupations = personOccupations;
        }

        public override string BackNavigationPath => $"People/Edit/{PersonId}";

        public override string ContinueNavigationPath => $"People/Team/Edit/{PersonId}";

        public override EditModeType EditModeType => PersonOccupations.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => $"Admin/EditDomainItems";

        public string ImagePath => "images/occupations.jpg";

        public override string ItemTitle => "Occupations";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Occupations";

        public int PersonId { get; set; }

        public List<SavePersonOccupationViewModel> PersonOccupations { get; set; } = new();

        public PersonStep PersonStep => PersonStep.Occupation;
    }
}
