#nullable disable

namespace Memorabilia.Blazor.Pages.Admin;

public partial class DomainItemNavigator : ComponentBase
{
    public string DomainItemQuickJump { get; set; }
    public AdminDomainItemsViewModel ViewModel = new ();

    [Parameter]
    public EventCallback<string> OnNavigate { get; set; }

    public void Enter(KeyboardEventArgs e)
    {
        if (e.Code == "Enter" || e.Code == "NumpadEnter")
        {
            QuickJump();
        }
    }

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
