namespace Memorabilia.Application.Features.Admin;

public class SaveDomainViewModel : EditModel
{
    public SaveDomainViewModel() { }

    public SaveDomainViewModel(int id, string domainTypeName, string imageFileName, string navigationPath)
    {
        Id = id;
        DomainTypeName = domainTypeName;
        ImageFileName = imageFileName;
        NavigationPath = navigationPath;
    }

    public SaveDomainViewModel(DomainViewModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        Id = viewModel.Id;
        Name = viewModel.Name;
    }

    public SaveDomainViewModel(DomainViewModel viewModel, string domainTypeName, string imageFileName, string navigationPath)
    {
        Abbreviation = viewModel.Abbreviation;
        Id = viewModel.Id;
        Name = viewModel.Name;

        DomainTypeName = domainTypeName;
        ImageFileName = imageFileName;
        NavigationPath = navigationPath;
    }

    public string Abbreviation { get; set; }

    public string DomainTypeName { get; set; }        

    public string ImageFileName { get; set; }        

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public string NavigationPath { get; set; }

    public virtual string PageFooterNavigationPath => NavigationPath;

    public override string PageTitle => $"{(EditModeType == Constant.EditModeType.Update ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} {DomainTypeName}";
}
