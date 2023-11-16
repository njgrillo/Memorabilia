namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public class AccomplishmentsModel
{
    public AccomplishmentsModel() { }

    public AccomplishmentsModel(IEnumerable<Entity.PersonAccomplishment> personAccomplishments, 
                                Constant.Sport sport)
    {
        PersonAccomplishments 
            = personAccomplishments.Select(accomplishment => new AccomplishmentModel(accomplishment, sport))
                                   .ToList();
    }

    public Constant.AccomplishmentType AccomplishmentType { get; set; }

    public string AccomplishmentTypeName
        => AccomplishmentType?.Name;

    public bool IsDateAccomplishment 
        => AccomplishmentType?.IsDateAccomplishment() ?? false;

    public bool IsNoHitter 
        => true;

    public bool IsYearAccomplishment 
        => AccomplishmentType?.IsYearAccomplishment() ?? false;

    public List<AccomplishmentModel> PersonAccomplishments { get; set; } 
        = [];
}
