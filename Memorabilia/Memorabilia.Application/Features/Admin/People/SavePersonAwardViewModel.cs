using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonAwardViewModel : EditModel
{
    public SavePersonAwardViewModel() { }

    public SavePersonAwardViewModel(PersonAward award)
    {
        AwardType = Constant.AwardType.Find(award.AwardTypeId);
        Id = award.Id;
        PersonId = award.PersonId;
        Year = award.Year;
    }

    public Constant.AwardType AwardType { get; set; }

    public string AwardTypeName => AwardType?.Name;

    public int PersonId { get; set; }

    public int Year { get; set; }
}
