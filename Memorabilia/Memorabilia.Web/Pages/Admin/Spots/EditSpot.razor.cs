﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.Spots;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Spots
{
    public partial class EditSpot : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Spot";
        private const string ImagePath = "images/spots.jpg";
        private const string NavigationPath = $"{DomainTypeName}s";

        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetSpot.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 NavigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveSpot.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
