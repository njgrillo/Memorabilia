namespace Memorabilia.Blazor.Pages.Admin.People;

public abstract class EditPersonItem<TSaveViewModel, TViewModel> : EditItem<TSaveViewModel, TViewModel>
{
    [Parameter]
    public int PersonId { get; set; }
}
