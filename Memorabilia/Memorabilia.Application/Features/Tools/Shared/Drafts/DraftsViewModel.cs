using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public class DraftsViewModel
{
    public DraftsViewModel() { }

    public DraftsViewModel(IEnumerable<Draft> drafts, Domain.Constants.Sport sport)
    {
        Drafts = drafts.Select(draft => new DraftViewModel(draft, sport))
                       .OrderByDescending(draft => draft.Year)
                       .ThenBy(draft => draft.Round)
                       .ThenBy(draft => draft.Pick);
    }    

    public IEnumerable<DraftViewModel> Drafts { get; set; } = Enumerable.Empty<DraftViewModel>();

    public Domain.Constants.Franchise Franchise { get; set; }

    public string FranchiseName => Franchise?.Name;

    public string ResultsTitle => $"{FranchiseName} Draft Picks";
}
