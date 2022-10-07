using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Awards;

public class AwardViewModel
{
    private readonly PersonAward _personAward;

    public AwardViewModel(PersonAward personAward)
    {
        _personAward = personAward;
    }

    public int AwardTypeId => _personAward.AwardTypeId;

    public string AwardTypeName => Domain.Constants.AwardType.Find(AwardTypeId)?.Name;

    public int PersonId => _personAward.PersonId;

    public string PersonImagePath => $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(_personAward.Person.ImagePath))}"; 
    
    public string PersonName => _personAward.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Year => _personAward.Year.ToString();
}
