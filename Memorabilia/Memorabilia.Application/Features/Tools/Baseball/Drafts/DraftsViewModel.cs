using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Drafts;

public class DraftsViewModel
{
    public DraftsViewModel() { }

    public DraftsViewModel(IEnumerable<Draft> drafts)
    {
        Drafts = drafts.Select(draft => new DraftViewModel(draft))
                       .OrderByDescending(draft => draft.Year)
                       .ThenBy(draft => draft.Round)
                       .ThenBy(draft => draft.Pick);
    }    

    public IEnumerable<DraftViewModel> Drafts { get; set; } = Enumerable.Empty<DraftViewModel>();

    public int FranchiseId { get; set; }

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
