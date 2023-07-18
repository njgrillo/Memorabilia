namespace Memorabilia.Application.Features.Admin.Management.Awards;

public class AwardManagementModel
{
    private readonly Entity.AwardDetail _awardDetail;

    public AwardManagementModel() { }

    public AwardManagementModel(int awardTypeId)
    {
        _awardDetail = new(awardTypeId);
    }

    public AwardManagementModel(Entity.AwardDetail awardDetail)
    {
        _awardDetail = awardDetail;
        AwardDetailId= awardDetail.Id;
    }

    public int AwardDetailId { get; set; }

    public Constant.AwardType AwardType
        => Constant.AwardType.Find(AwardTypeId);

    public int AwardTypeId
        => _awardDetail.AwardTypeId;

    public int BeginYear
        => _awardDetail.BeginYear;

    public int? EndYear
        => _awardDetail.EndYear;    

    public bool HasMissingYears
        => MissingYears.Any();

    public bool IsConfigured
        => BeginYear > 0;

    public int[] MissingYears { get; set; }
        = Array.Empty<int>();

    public int? MonthAwarded 
        => _awardDetail.MonthAwarded;

    public int? NumberOfWinners
        => _awardDetail.NumberOfWinners;

    public bool NumberOfWinnersDoesntMatch { get; set; }
}
