using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Drafts;

public class DraftViewModel
{
    private readonly Draft _draft;

    public DraftViewModel(Draft draft)
    {
        _draft = draft;
    }

    public int FranchiseId => _draft.FranchiseId;

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public string Overall => _draft.Overall.HasValue ? _draft.Overall.ToString() : string.Empty;

    public int PersonId => _draft.PersonId;

    public string PersonImageFileName => _draft.Person.ImageFileName;

    public string PersonName => _draft.Person.DisplayName;

    public string Pick => _draft.Pick.HasValue ? _draft.Pick.ToString() : string.Empty;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Round => _draft.Round.ToString();

    public string Year => _draft.Year.ToString();
}
