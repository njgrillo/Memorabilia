namespace Memorabilia.Application.Features.Admin;

public class DomainEditModel : EditModel
{
    public DomainEditModel() { }

    public DomainEditModel(int id, string domainTypeName, string imageFileName, string navigationPath)
    {
        Id = id;
        DomainTypeName = domainTypeName;
        ImageFileName = imageFileName;
        NavigationPath = navigationPath;
    }

    public DomainEditModel(DomainModel model)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        Name = model.Name;
    }

    public DomainEditModel(DomainModel model, string domainTypeName, string imageFileName, string navigationPath)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        Name = model.Name;

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

    public virtual string PageFooterNavigationPath 
        => NavigationPath;

    public override string PageTitle 
        => $"{EditModeType.ToEditModeTypeName()} {DomainTypeName}";
}
