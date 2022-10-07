using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonImageViewModel : SaveViewModel
{
    public SavePersonImageViewModel() { }

    public SavePersonImageViewModel(PersonImageViewModel viewModel)
    {
        ImagePath = viewModel.ImagePath;
        PersonId = viewModel.PersonId;
    }

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/HallOfFame/{EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath => "Admin/EditDomainItems";

    public override EditModeType EditModeType => !ImagePath.IsNullOrEmpty() ? EditModeType.Update : EditModeType.Add;

    public string ImagePath { get; set; }

    public override string ItemTitle => "Image";

    public string PageImagePath => Domain.Constants.ImagePath.Images;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} Image";

    public int PersonId { get; set; }

    public PersonStep PersonStep => PersonStep.Image;

    public string SaveReturnNavigationPath => AdminDomainItem.People.Page;
}
