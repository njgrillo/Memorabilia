namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class PersonProfileMain : ImagePage
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    private Domain.Entities.Person _person;
    private PersonProfileModel _viewModel;

    protected override async Task OnParametersSetAsync()
    {
        if (PersonId == 0)
            return;

        _person = await Mediator.Send(new GetPersonGeneric(PersonId));

        _viewModel = new PersonProfileModel(_person);
    }
}
