namespace Memorabilia.Application.Features.Admin.Management.Awards;

public class AwardExclusionYearEditModel : EditModel
{
    public AwardExclusionYearEditModel() { }

    public AwardExclusionYearEditModel(Entity.AwardExclusionYear awardExclusionYear)
    {
        Id = awardExclusionYear.Id;
        Reason = awardExclusionYear.Reason;
        Year = awardExclusionYear.Year;
    }

    public string Reason { get; set; }

    public int Year { get; set; }
}
