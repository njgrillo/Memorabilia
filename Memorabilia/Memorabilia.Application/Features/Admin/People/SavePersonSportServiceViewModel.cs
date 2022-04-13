using Memorabilia.Domain.Constants;
using System;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonSportServiceViewModel : SaveViewModel
    {
        public SavePersonSportServiceViewModel() { }

        public SavePersonSportServiceViewModel(int personId, PersonSportServiceViewModel viewModel)
        {
            DebutDate = viewModel.DebutDate;
            FreeAgentSigningDate = viewModel.FreeAgentSigningDate;
            LastAppearanceDate = viewModel.LastAppearanceDate;
            PersonId = personId;
        }

        public override string BackNavigationPath => $"People/Occupation/Edit/{PersonId}";

        public override string ContinueNavigationPath => $"People/Team/Edit/{PersonId}";

        public DateTime? DebutDate { get; set; }

        public override EditModeType EditModeType => DebutDate.HasValue || 
                                                     FreeAgentSigningDate.HasValue || 
                                                     LastAppearanceDate.HasValue ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => $"Admin/EditDomainItems";

        public DateTime? FreeAgentSigningDate { get; set; }

        public DateTime? LastAppearanceDate { get; set; }

        public string ImagePath => "images/athletes.jpg";

        public override string ItemTitle => "Sport Service";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Sport Service";

        public int PersonId { get; set; }

        public PersonStep PersonStep => PersonStep.SportService;
    }
}
