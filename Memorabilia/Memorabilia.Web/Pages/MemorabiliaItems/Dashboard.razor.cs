﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems
{
    public partial class Dashboard : ComponentBase
    {
        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private DashboardViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            _viewModel = await QueryRouter.Send(new GetDashboard.Query(userId.Value)).ConfigureAwait(false);
        }
    }
}
