namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public class RetiredNumbersModel
{
    public RetiredNumbersModel() { }

    public RetiredNumbersModel(IEnumerable<Entity.RetiredNumber> retiredNumbers, Constant.Sport sport)
    {
        RetiredNumbers = retiredNumbers.Select(retiredNumber => new RetiredNumberModel(retiredNumber, sport))
                                       .OrderBy(retiredNumber => retiredNumber.PersonName);
    }

    public Constant.Franchise Franchise { get; set; }

    public string FranchiseName 
        => Franchise?.Name;

    public string ResultsTitle 
        => $"{FranchiseName} Retired Numbers";

    public IEnumerable<RetiredNumberModel> RetiredNumbers { get; set; } 
        = Enumerable.Empty<RetiredNumberModel>();
}
