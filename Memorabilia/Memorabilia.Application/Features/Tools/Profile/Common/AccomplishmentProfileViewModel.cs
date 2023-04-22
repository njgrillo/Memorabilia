using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AccomplishmentProfileViewModel
{
    private readonly PersonAccomplishment _accomplishment;

    public AccomplishmentProfileViewModel(PersonAccomplishment accomplishment)
    {
        _accomplishment = accomplishment;
    }

    public Domain.Constants.AccomplishmentType AccomplishmentType 
        => Domain.Constants.AccomplishmentType.Find(AccomplishmentTypeId);

    public string AccomplishmentTypeAbbreviation 
        => AccomplishmentType?.Abbreviation;

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
}
