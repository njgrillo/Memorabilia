#nullable disable

namespace Memorabilia.Blazor.Pages.Admin;

public partial class DomainItemNavigator : ComponentBase
{
    public string DomainItemQuickJump { get; set; }
    public readonly AdminDomainItemsViewModel ViewModel = new ();

    public string ImageRoot => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles), "GraphinAllDay");

    [Parameter]
    public EventCallback<string> OnNavigate { get; set; }

    public async void QuickJump()
    {
        if (DomainItemQuickJump.IsNullOrEmpty())
            return;

        var domainItem = ViewModel.Items.SingleOrDefault(item => item.Title.Equals(DomainItemQuickJump, StringComparison.OrdinalIgnoreCase));

        if (domainItem == null)
            return;

        await OnNavigate.InvokeAsync(domainItem.Page);
    }
}
