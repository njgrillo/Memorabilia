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
        = new();

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/Image/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override Constant.EditModeType EditModeType 
        => HallOfFames.Any() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public List<PersonFranchiseHallOfFameEditModel> FranchiseHallOfFames { get; set; } 
        = new();

    public List<PersonHallOfFameEditModel> HallOfFames { get; set; } 
        = new();

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public List<PersonInternationalHallOfFameEditModel> InternationalHallOfFames { get; set; } 
        = new();

    public override string ItemTitle 
        => "Hall of Fames";

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Update ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} Hall of Fames";

    public int PersonId { get; set; }

    public Constant.PersonStep PersonStep
        => Constant.PersonStep.HallOfFame;

    public Constant.Sport[] Sports { get; set; } 
        = Array.Empty<Constant.Sport>();

    public Constant.SportLeagueLevel[] SportLeagueLevels { get; set; } 
        = Constant.SportLeagueLevel.All;
}
