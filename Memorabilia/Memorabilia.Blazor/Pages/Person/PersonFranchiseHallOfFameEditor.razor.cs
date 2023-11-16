namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonFranchiseHallOfFameEditor
{
    [Parameter]
    public List<PersonFranchiseHallOfFameEditModel> FranchiseHallOfFames { get; set; } 
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonFranchiseHallOfFameEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        if (Model.FranchiseHallOfFameType == null)
            return;

        FranchiseHallOfFames.Add(Model);

        Model = new PersonFranchiseHallOfFameEditModel();
    }

    private void Edit(PersonFranchiseHallOfFameEditModel hallOfFame)
    {
        Model.FranchiseHallOfFameType = hallOfFame.FranchiseHallOfFameType;
        Model.Year = hallOfFame.Year;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonFranchiseHallOfFameEditModel hallOfFame
           = FranchiseHallOfFames.Single(hof => hof.FranchiseHallOfFameType.Id == Model.FranchiseHallOfFameType.Id);

        hallOfFame.FranchiseHallOfFameType = Model.FranchiseHallOfFameType;
        hallOfFame.Year = Model.Year;

        Model = new();

        EditMode = EditModeType.Add;
    }
}
