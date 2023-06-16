namespace Memorabilia.Blazor.Controls;

public partial class DomainItems
{
    [Parameter]
    public DomainsModel Items
    {
        get
        {
            return Model;
        }
        set
        {
            Model = value;
        }
    }

    [Parameter]
    public EventCallback<DomainEditModel> OnDelete { get; set; }

    protected DomainsModel Model;

    protected async Task Delete(DomainEditModel editModel)
    {
        await OnDelete.InvokeAsync(editModel);
    }
}
