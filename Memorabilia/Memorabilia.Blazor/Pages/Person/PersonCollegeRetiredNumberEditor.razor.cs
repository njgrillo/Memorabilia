namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCollegeRetiredNumberEditor
{
    [Parameter]
    public List<PersonCollegeRetiredNumberEditModel> CollegeRetiredNumbers { get; set; } 
        = [];

    [Parameter]
    public College[] Colleges { get; set; }

    protected PersonCollegeRetiredNumberEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        if (Model.College == null || !Model.PlayerNumber.HasValue)
            return;

        CollegeRetiredNumbers.Add(Model);

        Model = new PersonCollegeRetiredNumberEditModel();
    }

    private void Edit(PersonCollegeRetiredNumberEditModel CollegeRetiredNumber)
    {
        Model.College = CollegeRetiredNumber.College;
        Model.PlayerNumber = CollegeRetiredNumber.PlayerNumber;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonCollegeRetiredNumberEditModel number 
            = CollegeRetiredNumbers.SingleOrDefault(number => number.College?.Id == Model.College?.Id);

        if (number is not null)
        {
            number.College = Model.College;
            number.PlayerNumber = Model.PlayerNumber;
        }        

        Model = new();

        EditMode = EditModeType.Add;
    }
}
