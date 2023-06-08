namespace Memorabilia.Blazor.Pages.Admin;

public partial class DomainItemNavigator
{
    public string DomainItemQuickJump { get; set; }
    public AdminDomainItemsModel ViewModel = new ();

    [Parameter]
    public EventCallback<string> OnNavigate { get; set; }

    private bool _displayItemTypeNotFound;

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
        {
            _displayItemTypeNotFound = true;
            return;
        }

        var domainItem = ViewModel.Items.SingleOrDefault(item => item.Title.Equals(DomainItemQuickJump, StringComparison.OrdinalIgnoreCase));

        if (domainItem == null)
        {
            _displayItemTypeNotFound = true;
            return;
        }

        await OnNavigate.InvokeAsync(domainItem.Page);
    }
}
