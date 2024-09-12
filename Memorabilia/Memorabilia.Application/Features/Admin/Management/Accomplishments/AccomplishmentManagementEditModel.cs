namespace Memorabilia.Application.Features.Admin.Management.Accomplishments;

public class AccomplishmentManagementEditModel : EditModel
{
    public AccomplishmentManagementEditModel() { }

    public AccomplishmentManagementEditModel(AccomplishmentManagementModel model)
    {
        AccomplishmentType = model.AccomplishmentType;
        BeginYear = model.BeginYear;
        EndYear = model.EndYear;
        Id = model.AccomplishmentDetailId;
        IgnoreManagement = model.IgnoreManagement;
        MonthAccomplished = model.MonthAccomplished;
        NumberOfWinners = model.NumberOfWinners;
        Year = model.Year;
    }

    public Constant.AccomplishmentType AccomplishmentType { get; set; }

    public int? BeginYear { get; set; }

    public int? EndYear { get; set; }

    public bool IgnoreManagement { get; set; }

    public int? MonthAccomplished { get; set; }

    public int? NumberOfWinners { get; set; }

    public int? Year { get; set; }
}
