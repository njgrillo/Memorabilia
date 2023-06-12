namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class SportLeagueLevelEditModel : EditModel
{
    public SportLeagueLevelEditModel() { }

    public SportLeagueLevelEditModel(SportLeagueLevelModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        Id = viewModel.Id;
        LevelTypeId = viewModel.LevelTypeId;
        Name = viewModel.Name;            
        SportId = viewModel.SportId;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.SportLeagueLevels.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.SportLeagueLevels.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.SportLeagueLevels.Item;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level Type is required.")]
    public int LevelTypeId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.SportLeagueLevels.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
    public int SportId { get; set; }
}
