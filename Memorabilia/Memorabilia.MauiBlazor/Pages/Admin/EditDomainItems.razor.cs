namespace Memorabilia.MauiBlazor.Pages.Admin
{
    public partial class EditDomainItems : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string _domainItemQuickJump;
        private readonly AdminDomainItemsViewModel _viewModel = new ();

        [Parameter]
        public int UserId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await SecureStorage.Default.GetAsync("UserId");

            UserId = userId.ToInt32();
        }

        protected async Task OnLoad()
        {
            //var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            //UserId = userId.Value;
        }

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
