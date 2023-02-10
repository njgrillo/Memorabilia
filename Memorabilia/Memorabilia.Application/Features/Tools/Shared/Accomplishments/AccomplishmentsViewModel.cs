using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public class AccomplishmentsViewModel
{
    public AccomplishmentsViewModel() { }

    public AccomplishmentsViewModel(IEnumerable<PersonAccomplishment> personAccomplishments, 
        Domain.Constants.Sport sport)
    {
        PersonAccomplishments 
            = personAccomplishments.Select(accomplishment => new AccomplishmentViewModel(accomplishment, sport))
                                   .ToList();
    }

    public Domain.Constants.AccomplishmentType AccomplishmentType { get; set; }

    public string AccomplishmentTypeName => AccomplishmentType?.Name;

    public bool IsDateAccomplishment 
        => AccomplishmentType != null && 
           Domain.Constants.AccomplishmentType.IsDateAccomplishment(AccomplishmentType.Id);

    public bool IsNoHitter => true;

    public bool IsYearAccomplishment 
        => AccomplishmentType != null && 
           Domain.Constants.AccomplishmentType.IsYearAccomplishment(AccomplishmentType.Id);

    public List<AccomplishmentViewModel> PersonAccomplishments { get; set; } = new();
}
