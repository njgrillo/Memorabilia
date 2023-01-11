using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class RecentPersonSportViewModel : RecentPersonEntityViewModel
{
    public RecentPersonSportViewModel(PersonSport personSport)
	{
        DisplayText = personSport.Sport.Name;
        Id = personSport.SportId;
	}
}
