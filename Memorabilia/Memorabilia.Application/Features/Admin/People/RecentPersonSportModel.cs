namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonSportModel : RecentPersonModel
{
    public bool IsPrimary { get; set; }

    public RecentPersonSportModel(Entity.PersonSport personSport)
	{
        DisplayText = $"{personSport.Sport.Name} - {(personSport.IsPrimary ? "Primary" : "Secondary")}";
        DisplayText = personSport.Sport.Name;
        Id = personSport.SportId;
        IsPrimary = personSport.IsPrimary;
	}
}
