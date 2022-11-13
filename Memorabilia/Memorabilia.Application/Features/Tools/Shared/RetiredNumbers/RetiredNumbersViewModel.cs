using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public class RetiredNumbersViewModel
{
    public RetiredNumbersViewModel() { }

    public RetiredNumbersViewModel(IEnumerable<RetiredNumber> retiredNumbers, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        RetiredNumbers = retiredNumbers.Select(retiredNumber => new RetiredNumberViewModel(retiredNumber, sportLeagueLevel))
                                       .OrderBy(retiredNumber => retiredNumber.PersonName);
    }

    public int FranchiseId { get; set; }

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public string ResultsTitle => $"{FranchiseName} Retired Numbers";

    public IEnumerable<RetiredNumberViewModel> RetiredNumbers { get; set; } = Enumerable.Empty<RetiredNumberViewModel>();
}
