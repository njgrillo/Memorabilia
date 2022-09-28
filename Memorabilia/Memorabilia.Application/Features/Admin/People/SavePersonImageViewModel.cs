using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonImageViewModel : SaveViewModel
    {
        public SavePersonImageViewModel() { }

        public SavePersonImageViewModel(PersonImageViewModel viewModel)
        {
            ImagePath = viewModel.ImagePath;
            PersonId = viewModel.PersonId;
        }

        public override string BackNavigationPath => $"People/HallOfFame/Edit/{PersonId}";

        public override string ContinueNavigationPath => "Admin/EditDomainItems";

        public override EditModeType EditModeType => !ImagePath.IsNullOrEmpty() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath { get; set; } = $"Admin/EditDomainItems";

        public string ImagePath { get; set; }

        public override string ItemTitle => "Image";

        public string PageImagePath => "images/images.png";

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Image";

        public int PersonId { get; set; }

        public PersonStep PersonStep => PersonStep.Image;

        public string SaveReturnNavigationPath => "People";
    }
}
