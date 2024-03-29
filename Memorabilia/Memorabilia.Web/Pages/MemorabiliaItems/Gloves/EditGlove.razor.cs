﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia.Glove;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Gloves
{
    public partial class EditGlove : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        private SaveGloveViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            _viewModel = new SaveGloveViewModel(await QueryRouter.Send(new GetGlove.Query(MemorabiliaId)).ConfigureAwait(false));
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveGlove.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
