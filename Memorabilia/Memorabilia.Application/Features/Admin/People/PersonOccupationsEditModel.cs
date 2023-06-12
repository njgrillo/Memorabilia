namespace Memorabilia.Application.Features.Admin.People;

public class PersonOccupationsEditModel : EditModel
{
    public PersonOccupationsEditModel() { }

    public PersonOccupationsEditModel(int personId, PersonOccupationModel model)
    {
        Occupations = model.Occupations.ToEditModelList();
        PersonId = personId;
        Positions = model.Positions.ToEditModelList();
        Sports = model.Sports.ToEditModelList();
    }

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/SportService/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override Constant.EditModeType EditModeType 
        => Occupations.Any() || Sports.Any() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public bool HasAthleteOccupation 
        => Occupations.Any(occupation => !occupation.IsDeleted && Constant.Occupation.IsSportOccupation(occupation.Occupation.Id));

    public bool HasPositionSport 
        => Occupations.Any(occupation => !occupation.IsDeleted && occupation.Occupation.Id == Constant.Occupation.Athlete.Id) && 
           Sports.Any(sport => !sport.IsDeleted && Constant.Sport.IsPositionSport(sport.Sport));

    public string ImageFileName 
        => Constant.AdminDomainItem.Occupations.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Occupations.Title; 

    public List<PersonOccupationEditModel> Occupations { get; set; } 
        = new();

    public int PersonId { get; set; }        

    public Constant.PersonStep PersonStep 
        => Constant.PersonStep.Occupation;

    public List<PersonPositionEditModel> Positions { get; set; } 
        = new();

    public List<PersonSportEditModel> Sports { get; set; } 
        = new();
}
