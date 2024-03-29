﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin;
using Memorabilia.Application.Features.Admin.AuthenticationCompanies;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.AuthenticationCompanies
{
    public partial class AuthenticationCompanies : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private AuthenticationCompaniesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveAuthenticationCompany.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetAuthenticationCompanies.Query()).ConfigureAwait(false);
        }
    }
}
