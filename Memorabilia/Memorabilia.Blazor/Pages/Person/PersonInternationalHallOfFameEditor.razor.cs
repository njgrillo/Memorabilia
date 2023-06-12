namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonInternationalHallOfFameEditor
{
    [Parameter]
    public List<PersonInternationalHallOfFameEditModel> InternationalHallOfFames { get; set; } 
        = new();

    protected PersonInternationalHallOfFameEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditInternationalHallOfFameType 
        = true;

    private bool _canUpdate;    

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

        _canAdd = false;
        _canEditInternationalHallOfFameType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonInternationalHallOfFameEditModel hallOfFame 
            = InternationalHallOfFames.Single(hof => hof.InternationalHallOfFameTypeId == Model.InternationalHallOfFameTypeId);

        hallOfFame.InternationalHallOfFameTypeId = Model.InternationalHallOfFameTypeId;
        hallOfFame.Year = Model.Year;

        Model = new();

        _canAdd = true;
        _canEditInternationalHallOfFameType = true;
        _canUpdate = false;
    }
}
