namespace Memorabilia.Web.Pages.Project
{
    public partial class EditProject : ComponentBase
    {  
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected int UserId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            UserId = userId.Value;
        }
    }
}
