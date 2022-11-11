using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.RetiredNumbers;

public class RetiredNumberViewModel
{
    private readonly RetiredNumber _retiredNumber;

    public RetiredNumberViewModel(RetiredNumber retiredNumber)
    {
        _retiredNumber = retiredNumber;
    }

    public string FranchiseName => _retiredNumber.Franchise.FullName;   

    public int PersonId => _retiredNumber.PersonId;

    public string PersonImageFileName => _retiredNumber.Person.ImageFileName;

    public string PersonName => _retiredNumber.Person.DisplayName;

    public int PlayerNumber => _retiredNumber.PlayerNumber;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";
}
