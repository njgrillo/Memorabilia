using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonSportViewModel : RecentPersonEntityViewModel
{
    public bool IsPrimary { get; set; }

    public RecentPersonSportViewModel(PersonSport personSport)
	{
        DisplayText = $"{personSport.Sport.Name} - {(personSport.IsPrimary ? "Primary" : "Secondary")}";
        DisplayText = personSport.Sport.Name;
        Id = personSport.SportId;
        IsPrimary = personSport.IsPrimary;
	}
}
