namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonRetiredNumberEditor
{
    [Parameter]
    public List<PersonRetiredNumberEditModel> RetiredNumbers { get; set; } 
        = [];

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
            = RetiredNumbers.SingleOrDefault(number => number.Franchise?.Id == Model.Franchise?.Id);

        if (number is not null)
        {
            number.Franchise = Model.Franchise;
            number.PlayerNumber = Model.PlayerNumber;
        }        

        Model = new();

        EditMode = EditModeType.Add;
    }
}
