using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonImageViewModel : EditModel
{
    public SavePersonImageViewModel() { }

    public SavePersonImageViewModel(PersonImageViewModel viewModel)
    {
        PersonImageFileName = viewModel.ImageFileName;
        PersonId = viewModel.PersonId;
    }

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/HallOfFame/{EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath => "Admin/EditDomainItems";

    public override EditModeType EditModeType => !PersonImageFileName.IsNullOrEmpty() ? EditModeType.Update : EditModeType.Add;

    public string ImageFileName => Constant.ImageFileName.Images;       

    public override string ItemTitle => "Image";    

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} Image";

    public int PersonId { get; set; }

    public string PersonImageFileName { get; set; }

    public PersonStep PersonStep => PersonStep.Image;

    public string SaveReturnNavigationPath => AdminDomainItem.People.Page;
}
