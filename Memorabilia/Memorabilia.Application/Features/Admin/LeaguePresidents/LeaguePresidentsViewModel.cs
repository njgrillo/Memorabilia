using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public class LeaguePresidentsViewModel : ViewModel
{
    public LeaguePresidentsViewModel() { }

    public LeaguePresidentsViewModel(IEnumerable<LeaguePresident> presidents)
    {
        Presidents = presidents.Select(president => new LeaguePresidentViewModel(president))
                               .OrderBy(president => president.SportLeagueLevelName)
                               .ThenByDescending(president => president.BeginYear)
                               .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";    

    public override string ItemTitle => AdminDomainItem.LeaguePresidents.Item;

    public override string PageTitle => AdminDomainItem.LeaguePresidents.Title;

    public List<LeaguePresidentViewModel> Presidents { get; set; } = new();

    public override string RoutePrefix => AdminDomainItem.LeaguePresidents.Page;
}
