#pragma checksum "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37aa2b485959afbc43f32d1c18acbb9ef48493b6"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Admin.AuthenticationCompanies
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Demo.Framework.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
using Memorabilia.Application.Features.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
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
#nullable restore
#line 12 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 15 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Memorabilia.Web.Shared.PopConfirm>(1);
            __builder.AddAttribute(2, "Title", "Delete Authentication Company");
            __builder.AddAttribute(3, "ConfirmedChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 20 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
                                  Delete

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(4, (__value) => {
#nullable restore
#line 18 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
                      _deleteDialog = (Memorabilia.Web.Shared.PopConfirm)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n    ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "row");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "col-md-12");
            __builder.AddAttribute(10, "style", "text-align: center");
            __builder.OpenElement(11, "h1");
#nullable restore
#line 23 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
__builder.AddContent(12, _viewModel.PageTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n    <br>\r\n    ");
            __builder.OpenElement(14, "table");
            __builder.AddAttribute(15, "class", "table");
            __builder.AddMarkupContent(16, "<thead><tr><th>Name</th>\r\n                <th>Abbreviation</th>\r\n                <th></th>\r\n                <th></th></tr></thead>\r\n        ");
            __builder.OpenElement(17, "tbody");
#nullable restore
#line 37 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
             foreach (var domainEntity in _viewModel.DomainEntities)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(18, "tr");
            __builder.OpenElement(19, "td");
#nullable restore
#line 40 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
__builder.AddContent(20, domainEntity.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                    ");
            __builder.OpenElement(22, "td");
#nullable restore
#line 41 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
__builder.AddContent(23, domainEntity.Abbreviation);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                    ");
            __builder.OpenElement(25, "td");
            __builder.OpenElement(26, "a");
            __builder.AddAttribute(27, "href", 
#nullable restore
#line 42 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
                                  $"AuthenticationCompanies/Edit/{domainEntity.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(28, "Edit");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                    ");
            __builder.OpenElement(30, "td");
            __builder.OpenElement(31, "button");
            __builder.AddAttribute(32, "class", "btn btn-danger");
            __builder.AddAttribute(33, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 43 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
                                                                    _ => ShowConfirm(domainEntity.Id) 

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(34, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 45 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n    ");
            __builder.AddMarkupContent(36, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><div class=\"col-md-12\" style=\"text-align: center\"><a href=\"AuthenticationCompanies/Add\">Add Authentication Company</a></div></div></div>\r\n    <br>");
#nullable restore
#line 56 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 58 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\AuthenticationCompanies\AuthenticationCompanies.razor"
       
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
