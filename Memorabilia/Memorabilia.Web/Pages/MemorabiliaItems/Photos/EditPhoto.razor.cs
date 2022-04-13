using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia.Photo;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Photos
{
    public partial class EditPhoto : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SavePhotoViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetPhoto.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SavePhotoViewModel(viewModel);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePhoto.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
        {
            _viewModel.SportIds = sportIds.ToList();
        }

        private void SetDefaults()
        {
            _viewModel.BrandId = Brand.None.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.OrientationId = Orientation.Portrait.Id;
            _viewModel.PhotoTypeId = PhotoType.Glossy.Id;
        }
    }
}
