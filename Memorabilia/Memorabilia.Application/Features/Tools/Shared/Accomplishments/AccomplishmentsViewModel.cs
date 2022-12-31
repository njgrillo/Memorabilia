using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public class AccomplishmentsViewModel
{
    public AccomplishmentsViewModel() { }

    public AccomplishmentsViewModel(IEnumerable<PersonAccomplishment> personAccomplishments, Domain.Constants.Sport sport)
    {
        PersonAccomplishments = personAccomplishments.Select(accomplishment => new AccomplishmentViewModel(accomplishment, sport));
    }

    public Domain.Constants.AccomplishmentType AccomplishmentType { get; set; }

    public string AccomplishmentTypeName => AccomplishmentType?.Name;

    public bool IsDateAccomplishment => AccomplishmentType != null && Domain.Constants.AccomplishmentType.IsDateAccomplishment(AccomplishmentType.Id);

    public bool IsYearAccomplishment => AccomplishmentType != null && Domain.Constants.AccomplishmentType.IsYearAccomplishment(AccomplishmentType.Id);

    public IEnumerable<AccomplishmentViewModel> PersonAccomplishments { get; set; } = Enumerable.Empty<AccomplishmentViewModel>();
}
