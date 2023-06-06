using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonHallOfFameViewModel : EditModel
{
    public SavePersonHallOfFameViewModel() { }

    public SavePersonHallOfFameViewModel(HallOfFame hallOfFame)
    {            
        BallotNumber = hallOfFame.BallotNumber ?? 0;
        Id = hallOfFame.Id;
        InductionYear = hallOfFame.InductionYear;
        PersonId = hallOfFame.PersonId;
        SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
        VotePercentage = hallOfFame.VotePercentage;
    }

    public int BallotNumber { get; set; }

    public string BallotNumberName => Constant.BallotNumber.Find(BallotNumber)?.Name;

    public Constant.BallotNumber[] BallotNumbers => Constant.BallotNumber.All;

    public int? InductionYear { get; set; }

    public int PersonId { get; set; }

    public int SportLeagueLevelId { get; set; }

    public Constant.SportLeagueLevel[] SportLeagueLevels => Constant.SportLeagueLevel.All;

    public string SportName => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;    

    public decimal? VotePercentage { get; set; }
}
