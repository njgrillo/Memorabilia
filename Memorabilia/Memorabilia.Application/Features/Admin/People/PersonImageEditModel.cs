namespace Memorabilia.Application.Features.Admin.People;

public class PersonImageEditModel : EditModel
{
    public PersonImageEditModel() { }

    public PersonImageEditModel(PersonImageModel model)
    {
        PersonImageFileName = model.ImageFileName;
        PersonId = model.PersonId;
    }

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/HallOfFame/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath 
        => "Admin/EditDomainItems";

    public override Constant.EditModeType EditModeType
        => !PersonImageFileName.IsNullOrEmpty() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public string ImageFileName 
        => Constant.ImageFileName.Images;       

    public override string ItemTitle 
        => "Image";    

    public override string PageTitle 
        => $"{EditModeType.ToEditModeTypeName()} Image";

    public int PersonId { get; set; }

    public string PersonImageFileName { get; set; }

    public Constant.PersonStep PersonStep 
        => Constant.PersonStep.Image;

    public string SaveReturnNavigationPath 
        => Constant.AdminDomainItem.People.Page;
}
