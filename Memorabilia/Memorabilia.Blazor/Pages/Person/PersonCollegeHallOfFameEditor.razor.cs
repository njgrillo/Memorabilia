namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCollegeHallOfFameEditor
{
    [Parameter]
    public List<PersonCollegeHallOfFameEditModel> CollegeHallOfFames { get; set; } 
        = [];

    [Parameter]
    public int[] SportIds { get; set; }

    protected PersonCollegeHallOfFameEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        if (Model.College == null)
            return;

        CollegeHallOfFames.Add(Model);

        Model = new PersonCollegeHallOfFameEditModel();
    }

    private void Edit(PersonCollegeHallOfFameEditModel hallOfFame)
    {
        Model.College = hallOfFame.College;
        Model.Sport = hallOfFame.Sport;
        Model.Year = hallOfFame.Year;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonCollegeHallOfFameEditModel hallOfFame 
            = CollegeHallOfFames.SingleOrDefault(hof => hof.Sport?.Id == Model.Sport?.Id);

        if (hallOfFame is not null)
        {
            hallOfFame.College = Model.College;
            hallOfFame.Sport = Model.Sport;
            hallOfFame.Year = Model.Year;
        }        

        Model = new();

        EditMode = EditModeType.Add;
    }
}
