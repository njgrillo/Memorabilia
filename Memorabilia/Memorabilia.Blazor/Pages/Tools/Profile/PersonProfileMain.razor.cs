namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class PersonProfileMain
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    protected PersonProfileModel Model;

    private Entity.Person _person;    

    protected override async Task OnParametersSetAsync()
    {
        if (PersonId == 0)
            return;

        _person = await Mediator.Send(new GetPerson(PersonId));

        Model = new PersonProfileModel(_person);
    }
}
