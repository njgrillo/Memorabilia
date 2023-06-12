namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCollegeHallOfFameEditor
{
    [Parameter]
    public List<PersonCollegeHallOfFameEditModel> CollegeHallOfFames { get; set; } 
        = new();

    [Parameter]
    public int[] SportIds { get; set; }

    protected PersonCollegeHallOfFameEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditCollege 
        = true;

    private bool _canUpdate;    

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

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonCollegeHallOfFameEditModel hallOfFame 
            = CollegeHallOfFames.Single(hof => hof.Sport.Id == Model.Sport.Id && 
                                               hof.Sport.Id == Model.Sport.Id);

        hallOfFame.College = Model.College;
        hallOfFame.Sport = Model.Sport;
        hallOfFame.Year = Model.Year;

        Model = new();

        _canAdd = true;
        _canEditCollege = true;
        _canUpdate = false;
    }
}
