﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia.Painting;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Paintings
{
    public partial class EditPainting : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SavePaintingViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetPainting.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SavePaintingViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePainting.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SetDefaults()
        {
            _viewModel.BrandId = Brand.None.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.OrientationId = Orientation.Portrait.Id;
            _viewModel.SizeId = Size.EightByTen.Id;
        }
    }
}
