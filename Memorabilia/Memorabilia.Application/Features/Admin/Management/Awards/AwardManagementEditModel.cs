namespace Memorabilia.Application.Features.Admin.Management.Awards;

public class AwardManagementEditModel : EditModel
{
    public AwardManagementEditModel() { }

    public AwardManagementEditModel(AwardManagementModel model)
    {        
        AwardType = model.AwardType;
        BeginYear = model.BeginYear;
        EndYear = model.EndYear;
        Id = model.AwardDetailId;
        MonthAwarded = model.MonthAwarded;
        NumberOfWinners = model.NumberOfWinners;
    }

    public Constant.AwardType AwardType { get; set; }

    public int? BeginYear { get; set; }
        = 1950;

    public int? EndYear { get; set; }

    public int? MonthAwarded { get; set; }

    public int? NumberOfWinners { get; set; }
}
