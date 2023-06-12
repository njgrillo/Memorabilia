namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonFranchiseHallOfFameEditor
{
    [Parameter]
    public List<PersonFranchiseHallOfFameEditModel> FranchiseHallOfFames { get; set; } 
        = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonFranchiseHallOfFameEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditFranchise 
        = true;

    private bool _canUpdate;    

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

        _canAdd = false;
        _canEditFranchise = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonFranchiseHallOfFameEditModel hallOfFame
           = FranchiseHallOfFames.Single(hof => hof.FranchiseHallOfFameType.Id == Model.FranchiseHallOfFameType.Id);

        hallOfFame.FranchiseHallOfFameType = Model.FranchiseHallOfFameType;
        hallOfFame.Year = Model.Year;

        Model = new();

        _canAdd = true;
        _canEditFranchise = true;
        _canUpdate = false;
    }
}
