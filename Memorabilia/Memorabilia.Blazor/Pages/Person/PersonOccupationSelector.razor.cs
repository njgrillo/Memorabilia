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

    private bool _canAdd 
        = true;

    private bool _canEditOccupation 
        = true;

    private bool _canUpdate;    

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

        _canAdd = false;
        _canEditOccupation = false;
        _canUpdate = true;

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

        _canAdd = true;
        _canEditOccupation = true;
        _canUpdate = false;

        await OnOccupationChange.InvokeAsync();
    }
}
