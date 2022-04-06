using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Conferences
{
    public class ConferencesViewModel : ViewModel
    {
        public ConferencesViewModel() { }

        public ConferencesViewModel(IEnumerable<Conference> conferences)
        {
            Conferences = conferences.Select(conference => new ConferenceViewModel(conference))
                         .OrderBy(conference => conference.Name)
                         .ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public List<ConferenceViewModel> Conferences { get; set; } = new();

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Conference";

        public override string PageTitle => "Conferences";

        public override string RoutePrefix => "Conferences";        
    }
}
