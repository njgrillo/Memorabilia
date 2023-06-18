namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonRetiredNumberEditor
{
    [Parameter]
    public List<PersonRetiredNumberEditModel> RetiredNumbers { get; set; } 
        = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonRetiredNumberEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        if (Model.Franchise == null || 
            !Model.PlayerNumber.HasValue)
            return;

        RetiredNumbers.Add(Model);

        Model = new PersonRetiredNumberEditModel();
    }

    private void Edit(PersonRetiredNumberEditModel retiredNumber)
    {
        Model.Franchise = retiredNumber.Franchise;
        Model.PlayerNumber = retiredNumber.PlayerNumber;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonRetiredNumberEditModel number 
            = RetiredNumbers.Single(number => number.Franchise.Id == Model.Franchise.Id);

        number.Franchise = Model.Franchise;
        number.PlayerNumber = Model.PlayerNumber;

        Model = new();

        EditMode = EditModeType.Add;
    }
}
