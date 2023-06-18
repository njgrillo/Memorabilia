namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonHallOfFameEditor
{
    [Parameter]
    public List<PersonHallOfFameEditModel> HallOfFames { get; set; } 
        = new();

    [Parameter]
    public SportLeagueLevel[] SportLeagueLevels { get; set; } 
        = SportLeagueLevel.All;

    protected PersonHallOfFameEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected override void OnInitialized()
    {
        if (SportLeagueLevels.Length == 1)
            Model.SportLeagueLevelId = SportLeagueLevels.First().Id;
    }

    private void Add()
    {
        if (Model.SportLeagueLevelId == 0)
            return;

        HallOfFames.Add(Model);

        Model = new PersonHallOfFameEditModel();

        if (SportLeagueLevels.Length == 1)
            Model.SportLeagueLevelId = SportLeagueLevels.First().Id;
    }

    private void Edit(PersonHallOfFameEditModel hallOfFame)
    {
        Model.BallotNumber = hallOfFame.BallotNumber;
        Model.InductionYear = hallOfFame.InductionYear;
        Model.SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
        Model.VotePercentage = hallOfFame.VotePercentage;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonHallOfFameEditModel hallOfFame 
            = HallOfFames.Single(hof => hof.SportLeagueLevelId == Model.SportLeagueLevelId);

        hallOfFame.BallotNumber = Model.BallotNumber;
        hallOfFame.InductionYear = Model.InductionYear;
        hallOfFame.VotePercentage = Model.VotePercentage;

        Model = new();

        EditMode = EditModeType.Add;

        if (SportLeagueLevels.Length == 1)
            Model.SportLeagueLevelId = SportLeagueLevels.First().Id;
    }
}
