#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Images
{
    public partial class EditMemorabiliaImage : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Parameter]
        public string UploadPath { get; set; }

        [Parameter]
        public int UserId { get; set; }

        private EditImages<SaveMemorabiliaImagesViewModel> EditImages;
        private SaveMemorabiliaImagesViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var memorabilia = await QueryRouter.Send(new GetMemorabiliaItem.Query(MemorabiliaId)).ConfigureAwait(false);

            _viewModel = new SaveMemorabiliaImagesViewModel(memorabilia.Images, memorabilia.ItemTypeName)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            _viewModel.Images = EditImages.Images;            

            await CommandRouter.Send(new SaveMemorabiliaImage.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
