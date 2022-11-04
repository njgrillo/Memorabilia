using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.AllStars;

public class AllStarViewModel
{
    private readonly AllStar _allstar;

    public AllStarViewModel(AllStar allstar)
    {
        _allstar = allstar;
    }

    public int PersonId => _allstar.PersonId;

    public string PersonImagePath => _allstar.Person.ImagePath;

    public string PersonName => _allstar.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Year => _allstar.Year.ToString();
}
