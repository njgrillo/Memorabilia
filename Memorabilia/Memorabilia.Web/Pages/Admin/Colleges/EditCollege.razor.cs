﻿
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.Colleges;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Colleges
{
    public partial class EditCollege : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private const string DomainTypeName = "College";
        private const string ImagePath = "images/colleges.jpg";
        private readonly string _navigationPath = $"{DomainTypeName}s";

        private SaveDomainViewModel _viewModel;

        protected override void OnInitialized()
        {
            _viewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, _navigationPath);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetCollege.Query(Id)).ConfigureAwait(false),
                                                 DomainTypeName,
                                                 ImagePath,
                                                 _navigationPath);
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveCollege.Command(_viewModel)).ConfigureAwait(false);
        }
    }
}
