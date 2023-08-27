namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

public class AccomplishmentManagementModel
{
    private readonly Entity.AccomplishmentDetail _accomplishmentDetail;

    public AccomplishmentManagementModel() { }

    public AccomplishmentManagementModel(int accomplishmentTypeId)
    {
        _accomplishmentDetail = new(accomplishmentTypeId);
    }

    public AccomplishmentManagementModel(Entity.AccomplishmentDetail accomplishmentDetail)
    {
        _accomplishmentDetail = accomplishmentDetail;
        AccomplishmentDetailId = accomplishmentDetail.Id;
    }

    public int AccomplishmentDetailId { get; set; }

    public Constant.AccomplishmentType AccomplishmentType
        => Constant.AccomplishmentType.Find(AccomplishmentTypeId);

    public int AccomplishmentTypeId
        => _accomplishmentDetail.AccomplishmentTypeId;

    public int? BeginYear
        => _accomplishmentDetail.BeginYear;

    public int? EndYear
        => _accomplishmentDetail.EndYear;

    public bool HasMissingYears
        => MissingYears.Any();

    public bool IsConfigured
        => NumberOfWinners > 0;

    public int[] MissingYears { get; set; }
        = Array.Empty<int>();

    public int? MonthAccomplished
        => _accomplishmentDetail.MonthAccomplished;

    public int? NumberOfWinners
        => _accomplishmentDetail.NumberOfWinners;

    public bool NumberOfWinnersDoesntMatch { get; set; }

    public int? Year { get; set; }
}
