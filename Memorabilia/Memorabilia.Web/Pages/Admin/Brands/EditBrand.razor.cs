﻿
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.Brands;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Brands
{
    public partial class EditBrand : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Brand";
        private const string ImagePath = "images/brands.jpg";
        private readonly string _navigationPath = $"{DomainTypeName}s";

        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, _navigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetBrand.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 _navigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveBrand.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
