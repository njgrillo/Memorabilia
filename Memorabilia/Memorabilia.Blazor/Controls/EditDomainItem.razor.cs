namespace Memorabilia.Blazor.Controls;

public partial class EditDomainItem
{
    [Parameter]
    public DomainEditModel EditModel { get; set; }

    [Parameter]
    public int MaxAbbreviationLength { get; set; } 
        = 10;

    [Parameter]
    public int MaxNameLength { get; set; } 
        = 100;

    [Parameter]
    public EventCallback<DomainEditModel> OnSave { get; set; }

    protected async Task Save()
    {
        await OnSave.InvokeAsync(EditModel);
    }
}
