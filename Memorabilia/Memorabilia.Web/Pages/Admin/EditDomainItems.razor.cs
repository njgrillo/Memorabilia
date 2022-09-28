namespace Memorabilia.Web.Pages.Admin
{
    public partial class EditDomainItems : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string _domainItemQuickJump;
        private readonly AdminDomainItemsViewModel _viewModel = new ();

        public async Task OnLoad() { }

        public void QuickJump()
        {
            if (_domainItemQuickJump.IsNullOrEmpty())
                return;

            var domainItem = _viewModel.Items.SingleOrDefault(item => item.Title.Equals(_domainItemQuickJump, StringComparison.OrdinalIgnoreCase));

            if (domainItem == null)
                return;

            NavigationManager.NavigateTo(domainItem.Page);
        }
    }
}
