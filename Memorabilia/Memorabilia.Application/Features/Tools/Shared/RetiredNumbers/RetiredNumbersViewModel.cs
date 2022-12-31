using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public class RetiredNumbersViewModel
{
    public RetiredNumbersViewModel() { }

    public RetiredNumbersViewModel(IEnumerable<RetiredNumber> retiredNumbers, Domain.Constants.Sport sport)
    {
        RetiredNumbers = retiredNumbers.Select(retiredNumber => new RetiredNumberViewModel(retiredNumber, sport))
                                       .OrderBy(retiredNumber => retiredNumber.PersonName);
    }

    public Domain.Constants.Franchise Franchise { get; set; }

    public string FranchiseName => Franchise?.Name;

    public string ResultsTitle => $"{FranchiseName} Retired Numbers";

    public IEnumerable<RetiredNumberViewModel> RetiredNumbers { get; set; } = Enumerable.Empty<RetiredNumberViewModel>();
}
