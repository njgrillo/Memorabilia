namespace Memorabilia.Application.Features.Admin.People;

public class PersonHallOfFamesEditModel : EditModel
{
    public PersonHallOfFamesEditModel() { }

    public PersonHallOfFamesEditModel(int personId, PersonHallOfFameModel model)
    {
        PersonId = personId;
        CollegeHallOfFames = model.CollegeHallOfFames.ToEditModelList();
        FranchiseHallOfFames = model.FranchiseHallOfFames.ToEditModelList();
        HallOfFames = model.HallOfFames.ToEditModelList();
        InternationalHallOfFames = model.InternationalHallOfFames.ToEditModelList();        
        Sports = model.Sports.ToConstantArray();
        SportLeagueLevels = Constant.SportLeagueLevel.GetAll(model.Sports
                                                                  .Select(sport => sport.SportId)
                                                                  .ToArray());
    }

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/Accolade/{Constant.EditModeType.Update.Name}/{PersonId}";

    public List<PersonCollegeHallOfFameEditModel> CollegeHallOfFames { get; set; } 
        = [];

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/Image/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override Constant.EditModeType EditModeType 
        => HallOfFames.Count != 0
            ? Constant.EditModeType.Update 
            : Constant.EditModeType.Add;

    public List<PersonFranchiseHallOfFameEditModel> FranchiseHallOfFames { get; set; } 
        = [];

    public List<PersonHallOfFameEditModel> HallOfFames { get; set; } 
        = [];

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public List<PersonInternationalHallOfFameEditModel> InternationalHallOfFames { get; set; } 
        = [];

    public override string ItemTitle 
        => "Hall of Fames";

    public string MenuItemPath
        => "People";

    public override string PageTitle 
        => $"{EditModeType.ToEditModeTypeName()} Hall of Fames";

    public int PersonId { get; set; }

    public Constant.PersonStep PersonStep
        => Constant.PersonStep.HallOfFame;

    public Constant.Sport[] Sports { get; set; } 
        = [];

    public Constant.SportLeagueLevel[] SportLeagueLevels { get; set; } 
        = Constant.SportLeagueLevel.All;
}
