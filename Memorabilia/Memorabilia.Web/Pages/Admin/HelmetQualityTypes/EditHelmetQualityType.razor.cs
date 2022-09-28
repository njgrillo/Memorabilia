﻿
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.HelmetQualityTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.HelmetQualityTypes
{
    public partial class EditHelmetQualityType : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Helmet Quality Type";
        private const string ImagePath = "images/fullsizehelmettypes.jpg";
        private readonly string _navigationPath = $"{DomainTypeName.Replace(" ", "")}s";

        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, _navigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetHelmetQualityType.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 _navigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveHelmetQualityType.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
