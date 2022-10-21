namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class AccoladePersonEditor : EditPersonItem<SavePersonAccoladeViewModel, PersonAccoladeViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonAccolades.Command(PersonId, ViewModel));
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonAccoladeViewModel(PersonId, await Get(new GetPersonAccomplishments(PersonId)));
    }    
}
