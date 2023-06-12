namespace Memorabilia.Application.Features.Admin.People;

public class PersonSportEditModel : EditModel
{
    public PersonSportEditModel() { }

    public PersonSportEditModel(Entity.PersonSport sport)
    {
        Id = sport.Id;
        IsPrimary= sport.IsPrimary;
        PersonId = sport.PersonId;
        Sport = Constant.Sport.Find(sport.SportId);
    }

    public bool IsPrimary { get; set; } 

    public int PersonId { get; set; }

    public Constant.Sport Sport { get; set; }

    public string SportName 
        => Sport?.Name;

    public string TypeName 
        => IsPrimary 
        ? "Primary" 
        : "Secondary";
}
