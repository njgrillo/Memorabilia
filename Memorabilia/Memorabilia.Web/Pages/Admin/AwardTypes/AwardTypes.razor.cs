﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.AwardTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.AwardTypes
{
    public partial class AwardTypes : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private AwardTypesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveAwardType.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetAwardTypes.Query()).ConfigureAwait(false);
        }
    }
}
