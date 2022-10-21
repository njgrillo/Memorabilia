namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class SportServicePersonEditor : EditPersonItem<SavePersonSportServiceViewModel, PersonSportServiceViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonSportService.Command(PersonId, ViewModel));
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonSportServiceViewModel(PersonId, 
                                                        await QueryRouter.Send(new GetPersonSportService(PersonId)));
    }    
}
