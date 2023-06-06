using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class SportLeagueLevelsViewModel : Model
{
    public SportLeagueLevelsViewModel() { }

    public SportLeagueLevelsViewModel(IEnumerable<Domain.Entities.SportLeagueLevel> sportLeagueLevels)
    {
        SportLeagueLevels = sportLeagueLevels.Select(sportLeagueLevel => new SportLeagueLevelViewModel(sportLeagueLevel))
                                             .OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                                             .ThenBy(sportLeagueLevel => sportLeagueLevel.Name)
                                             .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle => AdminDomainItem.SportLeagueLevels.Item;

    public override string PageTitle => AdminDomainItem.SportLeagueLevels.Title;

    public override string RoutePrefix => AdminDomainItem.SportLeagueLevels.Page;

    public List<SportLeagueLevelViewModel> SportLeagueLevels { get; set; } = new();
}
