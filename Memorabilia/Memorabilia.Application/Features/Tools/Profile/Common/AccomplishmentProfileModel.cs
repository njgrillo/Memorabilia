namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AccomplishmentProfileModel(Entity.PersonAccomplishment accomplishment)
{
    public Constant.AccomplishmentType AccomplishmentType 
        => Constant.AccomplishmentType.Find(AccomplishmentTypeId);

    public string AccomplishmentTypeAbbreviation 
        => AccomplishmentType?.Abbreviation ?? string.Empty;

    public int AccomplishmentTypeId 
        => accomplishment.AccomplishmentTypeId;    

    public string AccomplishmentTypeName 
        => AccomplishmentType?.Name;

    public DateTime? Date 
        => accomplishment.Date;  

    public string TimeFrame 
        => Date?.ToString("MM/dd/yyyy") ?? Year?.ToString() ?? string.Empty;

    public int? Year 
        => accomplishment.Year;

    public override string ToString()
        => !AccomplishmentTypeAbbreviation.IsNullOrEmpty()
            ? AccomplishmentTypeAbbreviation
            : AccomplishmentTypeName;
}
