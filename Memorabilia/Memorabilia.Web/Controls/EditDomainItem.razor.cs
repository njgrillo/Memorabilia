﻿using Memorabilia.Application.Features.Admin;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls
{
    public partial class EditDomainItem : ComponentBase
    {
        [Parameter]
        public SaveDomainViewModel Item
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
            }
        }

        [Parameter]
        public EventCallback OnLoad { get; set; }

        [Parameter]
        public EventCallback<SaveDomainViewModel> OnSave { get; set; }

        private SaveDomainViewModel _viewModel;        

        protected async Task Load()
        {
            if (_viewModel.Id == 0)
                return;

            await OnLoad.InvokeAsync().ConfigureAwait(false);
        }

        protected async Task Save()
        {
            await OnSave.InvokeAsync(_viewModel).ConfigureAwait(false);
        }
    }
}
