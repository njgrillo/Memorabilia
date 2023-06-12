namespace Memorabilia.Application.Features.Admin.Sports;

public class SportEditModel : EditModel
{
    public SportEditModel() { }

    public SportEditModel(SportModel model)
    {
        AlternateName = model.AlternateName;
        Id = model.Id;
        Name = model.Name;
    }

    [StringLength(50, ErrorMessage = "Alternate Name is too long.")]
    public string AlternateName { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Sports.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Sports.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Sports.Item;

    [Required]
    [StringLength(50, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Sports.Page;
}
