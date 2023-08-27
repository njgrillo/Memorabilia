namespace Memorabilia.Application.Features.Admin.Management.AllStars;

public class AllStarManagementEditModel : EditModel
{
    public AllStarManagementEditModel() { }

    public AllStarManagementEditModel(AllStarManagementModel model)
    {
        Id = model.AllStarDetailId;
        MonthPlayed = model.MonthPlayed;
        NumberOfAllStars = model.NumberOfAllStars;
        SportLeagueLevelId = model.SportLeagueLevel.Id;
        Year = model.Year;
    }    

    public int? MonthPlayed { get; set; }

    public int? NumberOfAllStars { get; set; }

    public Constant.SportLeagueLevel SportLeagueLevel
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId);

    public int SportLeagueLevelId { get; set; }

    public int? Year { get; set; }
}
