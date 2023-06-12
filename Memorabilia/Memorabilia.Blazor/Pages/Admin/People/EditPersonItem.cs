namespace Memorabilia.Blazor.Pages.Admin.People;

public abstract class EditPersonItem<TSaveModel, TModel> 
    : EditItem<TSaveModel, TModel>
{
    [Parameter]
    public int PersonId { get; set; }
}
