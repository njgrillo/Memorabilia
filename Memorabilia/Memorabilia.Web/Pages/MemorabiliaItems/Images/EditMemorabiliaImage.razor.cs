namespace Memorabilia.Web.Pages.MemorabiliaItems.Images
{
    public partial class EditMemorabiliaImage : ComponentBase
    {
        [Inject]
        public IWebHostEnvironment Environment { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        protected string UploadPath { get; set; }

        protected int UserId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            UserId = userId.Value;
            UploadPath = Environment.ContentRootPath;
        }
    }
}
