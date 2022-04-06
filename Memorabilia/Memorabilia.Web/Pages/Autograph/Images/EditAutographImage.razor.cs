using Demo.Framework.Web;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Autograph.Image;
using Memorabilia.Application.Features.Memorabilia.Image;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Autograph.Images
{
    public partial class EditAutographImage : ComponentBase
    {
        [Parameter]
        public int AutographId { get; set; }

        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveAutographImagesViewModel _viewModel = new ();

        protected async Task OnImportClick()
        {
            var query = new GetMemorabiliaImages.Query(_viewModel.MemorabiliaId);
            var memorabliaImagesViewModel = await QueryRouter.Send(query).ConfigureAwait(false);
            var images = memorabliaImagesViewModel.Images
                                                  .Select(image => new Domain.Entities.AutographImage(_viewModel.AutographId,
                                                                                                      image.FilePath,
                                                                                                      image.ImageTypeId,
                                                                                                      image.UploadDate))
                                                  .ToList();

            _viewModel = new SaveAutographImagesViewModel(images, _viewModel.ItemType, _viewModel.MemorabiliaId, AutographId);
        }

        protected async Task OnLoad()
        {
            var autograph = await QueryRouter.Send(new GetAutograph.Query(AutographId)).ConfigureAwait(false);

            _viewModel = new SaveAutographImagesViewModel(autograph.Images, autograph.ItemType, autograph.MemorabiliaId, autograph.Id);
        }

        protected async Task OnSave()
        {
            _viewModel.AutographId = AutographId;

            await CommandRouter.Send(new SaveAutographImage.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
