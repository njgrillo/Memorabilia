using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public class AccomplishmentsViewModel
{
    public AccomplishmentsViewModel() { }

    public AccomplishmentsViewModel(IEnumerable<PersonAccomplishment> personAccomplishments, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        PersonAccomplishments = personAccomplishments.Select(accomplishment => new AccomplishmentViewModel(accomplishment, sportLeagueLevel));
    }

    public int AccomplishmentTypeId { get; set; }

    public string AccomplishmentTypeName => Domain.Constants.AccomplishmentType.Find(AccomplishmentTypeId)?.Name;

    public bool IsDateAccomplishment => AccomplishmentTypeId > 0 && Domain.Constants.AccomplishmentType.IsDateAccomplishment(AccomplishmentTypeId);

    public bool IsYearAccomplishment => AccomplishmentTypeId > 0 && Domain.Constants.AccomplishmentType.IsYearAccomplishment(AccomplishmentTypeId);

    public IEnumerable<AccomplishmentViewModel> PersonAccomplishments { get; set; } = Enumerable.Empty<AccomplishmentViewModel>();
}
