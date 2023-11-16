namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonSportEditor
{
    [Parameter]
    public EventCallback OnSportChange { get; set; }

    [Parameter]
    public List<PersonSportEditModel> Sports { get; set; } 
        = [];

    protected PersonSportEditModel Model 
        = new();

    protected override void OnInitialized()
    {
        Model.IsPrimary = Sports.Count == 0;
    }

    private async void Add()
    {
        if (Model.Sport == null)
            return;

        Sports.Add(Model);

        Model = new PersonSportEditModel
        {
            IsPrimary = false
        };

        await OnSportChange.InvokeAsync();
    }

    private void Delete(PersonSportEditModel sport)
    {
        sport.IsDeleted = true;

        Model.IsPrimary = Sports.All(sport => sport.IsDeleted);
    }
}
