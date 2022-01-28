// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Memorabilia.Web.Pages.Admin.HelmetTypes
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Demo.Framework.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\HelmetTypes\AuthenticationCompanies.razor"
using Memorabilia.Application.Features.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\HelmetTypes\AuthenticationCompanies.razor"
using Memorabilia.Application.Features.Admin.AuthenticationCompany;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AuthenticationCompanies")]
    public partial class AuthenticationCompanies : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 58 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\HelmetTypes\AuthenticationCompanies.razor"
       
    private PopConfirm _deleteDialog;
    private int _deletedItemId;
    private AuthenticationCompaniesViewModel _viewModel;

    protected async Task Delete(bool confirm)
    {
        if (!confirm)
        {
            _deletedItemId = 0;
            return;
        }

        var viewModel = new SaveDomainViewModel(_viewModel.DomainEntities.Single(domainEntity => domainEntity.Id == _deletedItemId));
        viewModel.IsDeleted = true;

        var command = new SaveAuthenticationCompany.Command(viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);
        await OnInitializedAsync().ConfigureAwait(false);

        _toastService.ShowSuccess("Authentication Company was deleted successfully!", _viewModel.PageTitle);
    }

    protected void Edit(int id)
    {
        _navigation.NavigateTo($"AuthenticationCompanies/Edit/{id}");
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        var query = new GetAuthenticationCompanies.Query();

        _viewModel = await _queryRouter.Send(query).ConfigureAwait(false);
    }

    protected void ShowConfirm(int id)
    {
        _deletedItemId = id;
        _deleteDialog.ShowPop();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService _toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private QueryRouter _queryRouter { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CommandRouter _commandRouter { get; set; }
    }
}
#pragma warning restore 1591
