using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public class DraftsViewModel
{
    public DraftsViewModel() { }

    public DraftsViewModel(IEnumerable<Draft> drafts, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        Drafts = drafts.Select(draft => new DraftViewModel(draft, sportLeagueLevel))
                       .OrderByDescending(draft => draft.Year)
                       .ThenBy(draft => draft.Round)
                       .ThenBy(draft => draft.Pick);
    }    

    public IEnumerable<DraftViewModel> Drafts { get; set; } = Enumerable.Empty<DraftViewModel>();

    public int FranchiseId { get; set; }

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public string ResultsTitle => $"{FranchiseName} Draft Picks";
}
