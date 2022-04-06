using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevel
{
    public class SportLeagueLevelsViewModel : ViewModel
    {
        public SportLeagueLevelsViewModel() { }

        public SportLeagueLevelsViewModel(IEnumerable<Domain.Entities.SportLeagueLevel> sportLeagueLevels)
        {
            SportLeagueLevels = sportLeagueLevels.Select(sportLeagueLevel => new SportLeagueLevelViewModel(sportLeagueLevel))
                                                 .OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                                                 .ThenBy(sportLeagueLevel => sportLeagueLevel.Name)
                                                 .ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Sport League Level";

        public override string PageTitle => "Sport League Levels";

        public override string RoutePrefix => "SportLeagueLevels";

        public List<SportLeagueLevelViewModel> SportLeagueLevels { get; set; } = new();
    }
}
