namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonOccupationSelector
{
    [Parameter]
    public List<PersonOccupationEditModel> Occupations { get; set; } 
        = new();

    [Parameter]
    public EventCallback OnOccupationChange { get; set; }

    protected PersonOccupationEditModel Model 
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected override void OnParametersSet()
    {
        if (Occupations.Any())
            Model.OccupationType = OccupationType.Secondary;
    }

    private async void Add()
    {
        if (Model.Occupation == null || Model.OccupationType == null)
            return;

        Occupations.Add(Model);

        Model = new PersonOccupationEditModel
        {
            OccupationType = OccupationType.Secondary
        };

        await OnOccupationChange.InvokeAsync();
    }

    private void Delete(PersonOccupationEditModel occupation)
    {
        occupation.IsDeleted = true;

        Model.OccupationType = Occupations.Any(occupation => !occupation.IsDeleted) 
            ? OccupationType.Secondary
            : OccupationType.Primary;
    }

    private async void Edit(PersonOccupationEditModel occupation)
    {
        Model.Occupation = occupation.Occupation;
        Model.OccupationType = occupation.OccupationType;

        EditMode = EditModeType.Update;

        await OnOccupationChange.InvokeAsync();
    }

    private void OnOccupationTypeChange(bool value)
    {
        Model.OccupationType = value 
            ? OccupationType.Primary 
            : OccupationType.Secondary;
    }

    private async void Update()
    {
        PersonOccupationEditModel occupation 
            = Occupations.Single(occupation => occupation.Occupation.Id == Model.Occupation.Id);

        occupation.Occupation = Model.Occupation;
        occupation.OccupationType = Model.OccupationType;

        Model = new();

        EditMode = EditModeType.Add;

        await OnOccupationChange.InvokeAsync();
    }
}
