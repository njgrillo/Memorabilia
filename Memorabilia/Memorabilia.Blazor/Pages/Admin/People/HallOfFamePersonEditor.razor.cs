namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class HallOfFamePersonEditor : EditPersonItem<SavePersonHallOfFamesViewModel, PersonHallOfFameViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonHallOfFame.Command(PersonId, ViewModel));
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonHallOfFamesViewModel(PersonId, await Get(new GetPersonHallOfFames(PersonId)));
    }    
}
