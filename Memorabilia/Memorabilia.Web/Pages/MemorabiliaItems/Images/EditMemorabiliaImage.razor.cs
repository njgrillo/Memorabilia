namespace Memorabilia.Web.Pages.MemorabiliaItems.Images
{
    public partial class EditMemorabiliaImage : WebPage
    {
        [Inject]
        public IWebHostEnvironment Environment { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        protected string UploadPath { get; set; }

        protected override void OnInitialized()
        {
            UploadPath = Environment.ContentRootPath;
        }
    }
}
