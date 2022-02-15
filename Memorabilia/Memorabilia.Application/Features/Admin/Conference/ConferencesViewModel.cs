using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.Conference
{
    public class ConferencesViewModel : ViewModel
    {
        public ConferencesViewModel() { }

        public ConferencesViewModel(IEnumerable<Domain.Entities.Conference> conferences)
        {
            Conferences = conferences.Select(conference => new ConferenceViewModel(conference))
                         .OrderBy(conference => conference.Name)
                         .ToList();
        }

        public List<ConferenceViewModel> Conferences { get; set; } = new();

        public override string ItemTitle => "Conference";

        public override string PageTitle => "Conferences";

        public override string RoutePrefix => "Conferences";        
    }
}
