﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.FigureTypes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.FigureTypes
{
    public partial class EditFigureType : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "Figure Type";
        private const string ImagePath = "images/figure.jpg";
        private readonly string _navigationPath = $"{DomainTypeName.Replace(" ", "")}s";

        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, _navigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetFigureType.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 _navigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveFigureType.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
