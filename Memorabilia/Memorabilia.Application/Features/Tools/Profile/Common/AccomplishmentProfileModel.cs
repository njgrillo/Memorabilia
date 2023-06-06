namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AccomplishmentProfileModel
{
    private readonly Entity.PersonAccomplishment _accomplishment;

    public AccomplishmentProfileModel(Entity.PersonAccomplishment accomplishment)
    {
        _accomplishment = accomplishment;
    }

    public Constant.AccomplishmentType AccomplishmentType 
        => Constant.AccomplishmentType.Find(AccomplishmentTypeId);

    public string AccomplishmentTypeAbbreviation 
        => AccomplishmentType?.Abbreviation ?? string.Empty;

    public int AccomplishmentTypeId 
        => _accomplishment.AccomplishmentTypeId;    

    public string AccomplishmentTypeName 
        => AccomplishmentType?.Name;

    public DateTime? Date 
        => _accomplishment.Date;  

    public string TimeFrame 
        => Date?.ToString("MM/dd/yyyy") ?? Year?.ToString() ?? string.Empty;

    public int? Year 
        => _accomplishment.Year;

    public override string ToString()
    {
        return !AccomplishmentTypeAbbreviation.IsNullOrEmpty() 
            ? AccomplishmentTypeAbbreviation
            : AccomplishmentTypeName;
    }
}
