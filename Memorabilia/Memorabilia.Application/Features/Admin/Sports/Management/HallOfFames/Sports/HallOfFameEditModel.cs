namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames.Sports;

public class HallOfFameEditModel : EditModel
{
    public HallOfFameEditModel() { }

    public HallOfFameEditModel(Entity.HallOfFame hallOfFame)
    {
        BallotNumber = hallOfFame.BallotNumber ?? 0;
        Id = hallOfFame.Id;
        InductionYear = hallOfFame.InductionYear;
        Person = new PersonModel(hallOfFame.Person);
        SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
        VotePercentage = hallOfFame.VotePercentage; 
    }

    public HallOfFameEditModel(
        int personId, 
        int sportLeagueLevelId, 
        int? inductionYear,
        decimal? votePercentage,
        int? ballotNumber)
    {
        BallotNumber = ballotNumber ?? 0;
        InductionYear = inductionYear;
        PersonId = personId;
        SportLeagueLevelId = sportLeagueLevelId;
        VotePercentage = votePercentage;
    }

    public int BallotNumber { get; set; }

    public string BallotNumberName
        => Constant.BallotNumber.Find(BallotNumber)?.Name;

    public int? InductionYear { get; set; }

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public int SportLeagueLevelId { get; set; }

    public string SportLeagueLeveleName
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;

    public Guid? TemporaryId { get; set; }
    
    public decimal? VotePercentage { get; set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }

    public bool Search(string search)
    {
        bool isNumber = int.TryParse(search, out var number);

        return search.IsNullOrEmpty() ||
               (isNumber && (InductionYear == number || BallotNumber == number)) ||
               Person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.Nicknames.Any(x => x.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
