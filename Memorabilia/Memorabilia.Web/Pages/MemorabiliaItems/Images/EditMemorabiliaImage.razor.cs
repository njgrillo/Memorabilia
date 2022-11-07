namespace Memorabilia.Web.Pages.MemorabiliaItems.Images
{
    public partial class EditMemorabiliaImage : WebPage
    {
        [Inject]
        public IConfiguration Configuration { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        protected string UploadPath { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId");

            UploadPath = Path.Combine(Configuration["MemorabiliaImageRootPath"], userId.Value.ToString());
        }
    }
}
