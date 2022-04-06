using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia;
using Memorabilia.Application.Features.Memorabilia.Image;
using Memorabilia.Web.Controls;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Images
{
    public partial class EditMemorabiliaImage : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

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
