namespace Memorabilia.Web.Pages.MemorabiliaItems.Images
{
    public partial class EditMemorabiliaImage : WebPage
    {
        [Parameter]
        public int MemorabiliaId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId");

            UploadPath = Path.Combine(MemorabiliaImageRootPath, userId.Value.ToString());
        }
    }
}
