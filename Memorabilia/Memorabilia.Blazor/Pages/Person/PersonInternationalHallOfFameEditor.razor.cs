namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonInternationalHallOfFameEditor
{
    [Parameter]
    public List<PersonInternationalHallOfFameEditModel> InternationalHallOfFames { get; set; } 
        = [];

    protected PersonInternationalHallOfFameEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        if (Model.InternationalHallOfFameTypeId == 0)
            return;

        InternationalHallOfFames.Add(Model);

        Model = new PersonInternationalHallOfFameEditModel();
    }

    private void Edit(PersonInternationalHallOfFameEditModel hallOfFame)
    {
        Model.InternationalHallOfFameTypeId = hallOfFame.InternationalHallOfFameTypeId;
        Model.Year = hallOfFame.Year;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonInternationalHallOfFameEditModel hallOfFame 
            = InternationalHallOfFames.SingleOrDefault(hof => hof.InternationalHallOfFameTypeId == Model.InternationalHallOfFameTypeId);

        if (hallOfFame is not null)
        {
            hallOfFame.InternationalHallOfFameTypeId = Model.InternationalHallOfFameTypeId;
            hallOfFame.Year = Model.Year;
        }        

        Model = new();

        EditMode = EditModeType.Add;
    }
}
