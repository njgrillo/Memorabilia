namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class SportLeagueLevelEditModel : EditModel
{
    public SportLeagueLevelEditModel() { }

    public SportLeagueLevelEditModel(SportLeagueLevelModel model)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        LevelTypeId = model.LevelTypeId;
        Name = model.Name;            
        SportId = model.SportId;
    }

    public string Abbreviation { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.SportLeagueLevels.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.SportLeagueLevels.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.SportLeagueLevels.Item;

    public int LevelTypeId { get; set; }

    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.SportLeagueLevels.Page;

    public int SportId { get; set; }
}
