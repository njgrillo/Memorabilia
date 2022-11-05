using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.RetiredNumbers;

public class RetiredNumbersViewModel
{
    public RetiredNumbersViewModel() { }

    public RetiredNumbersViewModel(IEnumerable<RetiredNumber> retiredNumbers)
    {
        RetiredNumbers = retiredNumbers.Select(retiredNumber => new RetiredNumberViewModel(retiredNumber))
                                       .OrderBy(retiredNumber => retiredNumber.PersonName);
    }

    public int FranchiseId { get; set; }

    public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

    public string ResultsTitle => $"{FranchiseName} Retired Numbers";

    public IEnumerable<RetiredNumberViewModel> RetiredNumbers { get; set; } = Enumerable.Empty<RetiredNumberViewModel>();

    public int SportLeagueLevelId => Domain.Constants.SportLeagueLevel.MajorLeagueBaseball.Id;
}
