using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonOccupationsViewModel : SaveViewModel
    {
        public SavePersonOccupationsViewModel() { }

        public SavePersonOccupationsViewModel(int personId, PersonOccupationViewModel viewModel)
        {
            Occupations = viewModel.Occupations.Select(occupation => new SavePersonOccupationViewModel(occupation)).ToList();
            PersonId = personId;
            Sports = viewModel.Sports.Select(sport => new SavePersonSportViewModel(sport)).ToList();
        }

        public override string BackNavigationPath => $"People/Edit/{PersonId}";

        public override string ContinueNavigationPath => $"People/SportService/Edit/{PersonId}";

        public override EditModeType EditModeType => Occupations.Any() || Sports.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => $"Admin/EditDomainItems";

        public bool HasAthleteOccupation => Occupations.Any(occupation => Occupation.IsSportOccupation(occupation.OccupationId));

        public string ImagePath => "images/occupations.jpg";

        public override string ItemTitle => "Occupations";

        public List<SavePersonOccupationViewModel> Occupations { get; set; } = new();

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Occupations";

        public int PersonId { get; set; }        

        public PersonStep PersonStep => PersonStep.Occupation;

        public List<SavePersonSportViewModel> Sports { get; set; } = new();
    }
}
