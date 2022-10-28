using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conferences;

public class ConferencesViewModel : ViewModel
{
    public ConferencesViewModel() { }

    public ConferencesViewModel(IEnumerable<Domain.Entities.Conference> conferences)
    {
        Conferences = conferences.Select(conference => new ConferenceViewModel(conference))
                                 .OrderBy(conference => conference.SportLeagueLevelName)
                                 .ThenBy(conference => conference.Name)
                                 .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<ConferenceViewModel> Conferences { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.Conferences.Item;

    public override string PageTitle => AdminDomainItem.Conferences.Title;

    public override string RoutePrefix => AdminDomainItem.Conferences.Page;
}
