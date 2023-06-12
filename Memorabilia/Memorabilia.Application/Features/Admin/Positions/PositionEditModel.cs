namespace Memorabilia.Application.Features.Admin.Positions;

public class PositionEditModel : EditModel
{
    public PositionEditModel() { }

    public PositionEditModel(PositionModel model)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        Name = model.Name;
        SportId = model.SportId;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Positions.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Positions.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Positions.Item;

    [Required]
    [StringLength(50, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Positions.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
    public int SportId { get; set; }
}
