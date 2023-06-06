using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Drafts;

public class DraftModel : PersonSportToolModel
{
    private readonly Draft _draft;

    public DraftModel(Draft draft, Constant.Sport sport)
    {
        _draft = draft;
        Sport = sport;
    }

    public int FranchiseId => _draft.FranchiseId;

    public string FranchiseName => Constant.Franchise.Find(FranchiseId)?.Name;

    public string Overall => _draft.Overall.HasValue ? _draft.Overall.ToString() : string.Empty;

    public override int PersonId => _draft.PersonId;

    public override string PersonImageFileName => _draft.Person.ImageFileName;

    public override string PersonName => _draft.Person.DisplayName;

    public string Pick => _draft.Pick.HasValue ? _draft.Pick.ToString() : string.Empty;

    public string Round => _draft.Round.ToString();

    public string Year => _draft.Year.ToString();
}
