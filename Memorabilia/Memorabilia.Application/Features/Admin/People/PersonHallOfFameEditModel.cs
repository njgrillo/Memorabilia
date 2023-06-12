namespace Memorabilia.Application.Features.Admin.People;

public class PersonHallOfFameEditModel : EditModel
{
    public PersonHallOfFameEditModel() { }

    public PersonHallOfFameEditModel(Entity.HallOfFame hallOfFame)
    {            
        BallotNumber = hallOfFame.BallotNumber ?? 0;
        Id = hallOfFame.Id;
        InductionYear = hallOfFame.InductionYear;
        PersonId = hallOfFame.PersonId;
        SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
        VotePercentage = hallOfFame.VotePercentage;
    }

    public int BallotNumber { get; set; }

    public string BallotNumberName 
        => Constant.BallotNumber.Find(BallotNumber)?.Name;

    public int? InductionYear { get; set; }

    public int PersonId { get; set; }

    public int SportLeagueLevelId { get; set; }

    public string SportName 
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;    

    public decimal? VotePercentage { get; set; }
}
