namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class OccupationPersonEditor : EditPersonItem<SavePersonOccupationsViewModel, PersonOccupationViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonOccupation.Command(PersonId, ViewModel));
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonOccupationsViewModel(PersonId, await QueryRouter.Send(new GetPersonOccupations(PersonId)));
    }    
}
