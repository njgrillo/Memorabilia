#pragma checksum "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc56eb887eee3e3fd048a3d362611aef7d046323"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Admin.ItemTypes
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Demo.Framework.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Framework.Extension;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
using Memorabilia.Application.Features.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
using Memorabilia.Application.Features.Admin.ItemType;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/ItemTypes")]
    public partial class ItemTypes : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 12 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 15 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Memorabilia.Web.Shared.PopConfirm>(1);
            __builder.AddAttribute(2, "Title", "Delete Item Type");
            __builder.AddAttribute(3, "ConfirmedChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 20 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
                                  Delete

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(4, (__value) => {
#nullable restore
#line 18 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
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
#line 23 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
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
            __builder.AddAttribute(16, "style", "border: 1px solid black;");
            __builder.AddMarkupContent(17, "<thead><tr><th>Name</th>\r\n                <th>Abbreviation</th>\r\n                <th></th>\r\n                <th></th></tr></thead>\r\n        ");
            __builder.OpenElement(18, "tbody");
#nullable restore
#line 37 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
             foreach (var domainEntity in _viewModel.DomainEntities)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(19, "tr");
            __builder.OpenElement(20, "td");
#nullable restore
#line 40 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
__builder.AddContent(21, domainEntity.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                    ");
            __builder.OpenElement(23, "td");
#nullable restore
#line 41 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
__builder.AddContent(24, domainEntity.Abbreviation);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                    ");
            __builder.OpenElement(26, "td");
            __builder.OpenComponent<Memorabilia.Web.Controls._Tooltip>(27);
            __builder.AddAttribute(28, "Text", "Edit");
            __builder.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(30, "img");
                __builder2.AddAttribute(31, "class", "can-click");
                __builder2.AddAttribute(32, "src", "images/pencil.png");
                __builder2.AddAttribute(33, "height", "25");
                __builder2.AddAttribute(34, "width", "25");
                __builder2.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 48 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
                                             _ => _navigation.NavigateTo($"{_viewModel.RoutePrefix}/Edit/{domainEntity.Id}")

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n                    ");
            __builder.OpenElement(37, "td");
            __builder.OpenComponent<Memorabilia.Web.Controls._Tooltip>(38);
            __builder.AddAttribute(39, "Text", "Delete");
            __builder.AddAttribute(40, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(41, "img");
                __builder2.AddAttribute(42, "class", "can-click");
                __builder2.AddAttribute(43, "src", "images/trash.png");
                __builder2.AddAttribute(44, "height", "25");
                __builder2.AddAttribute(45, "width", "25");
                __builder2.AddAttribute(46, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 57 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
                                             _ => ShowConfirm(domainEntity.Id)

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 61 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n    ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "row");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "col-md-12");
            __builder.AddAttribute(52, "style", "text-align: center");
            __builder.OpenElement(53, "div");
            __builder.AddAttribute(54, "class", "col-md-12");
            __builder.AddAttribute(55, "style", "text-align: center");
            __builder.OpenElement(56, "a");
            __builder.AddAttribute(57, "href", "ItemTypes/Add");
            __builder.AddContent(58, "Add ");
#nullable restore
#line 67 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
__builder.AddContent(59, _viewModel.ItemTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n    <br>");
#nullable restore
#line 72 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 74 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\ItemTypes\ItemTypes.razor"
       
    private PopConfirm _deleteDialog;
    private int _deletedItemId;
    private ItemTypesViewModel _viewModel;

    protected async Task Delete(bool confirm)
    {
        if (!confirm)
        {
            _deletedItemId = 0;
            return;
        }

        var deletedItem = _viewModel.DomainEntities.Single(domainEntity => domainEntity.Id == _deletedItemId);
        var viewModel = new SaveDomainViewModel(deletedItem);
        viewModel.IsDeleted = true;

        var command = new SaveItemType.Command(viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);
        
        _viewModel.DomainEntities.Remove(deletedItem);

        _toastService.ShowSuccess($"{_viewModel.ItemTitle} was deleted successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        var query = new GetItemTypes.Query();

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
