namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public class DraftsModel
{
    public DraftsModel() { }

    public DraftsModel(IEnumerable<Entity.Draft> drafts, Constant.Sport sport)
    {
        Drafts = drafts.Select(draft => new DraftModel(draft, sport))
                       .OrderByDescending(draft => draft.Year)
                       .ThenBy(draft => draft.Round)
                       .ThenBy(draft => draft.Pick);
    }    

    public IEnumerable<DraftModel> Drafts { get; set; } 
        = Enumerable.Empty<DraftModel>();

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName 
        => Franchise?.Name;

    public string ResultsTitle 
        => $"{FranchiseName} Draft Picks";
}
