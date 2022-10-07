using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Leagues;

public class LeaguesViewModel : ViewModel
{
    public LeaguesViewModel() { }

    public LeaguesViewModel(IEnumerable<Domain.Entities.League> leagues)
    {
        Leagues = leagues.Select(league => new LeagueViewModel(league))
                         .OrderBy(league => league.Name)
                         .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle => AdminDomainItem.Leagues.Item;

    public List<LeagueViewModel> Leagues { get; set; } = new();

    public override string PageTitle => AdminDomainItem.Leagues.Title;

    public override string RoutePrefix => AdminDomainItem.Leagues.Page;
}
