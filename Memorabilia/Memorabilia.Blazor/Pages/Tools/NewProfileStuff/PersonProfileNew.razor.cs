using Memorabilia.Application.Features.Tools.ProfileNew;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class PersonProfileNew : ImagePage
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    private Domain.Entities.Person _person;
    private PersonProfileNewViewModel _viewModel;

    protected override async Task OnParametersSetAsync()
    {
        if (PersonId == 0)
            return;

        _person = await Mediator.Send(new GetPersonGeneric(PersonId));

        _viewModel = new PersonProfileNewViewModel(_person);
    }
}
