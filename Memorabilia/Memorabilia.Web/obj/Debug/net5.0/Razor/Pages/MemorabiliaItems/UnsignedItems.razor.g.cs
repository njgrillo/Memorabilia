#pragma checksum "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a9e555c3460b870340083be2131fe7efb33fc69"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.MemorabiliaItems
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
#line 3 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
using Memorabilia.Application.Features.Memorabilia;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Memorabilia/UnsignedItems")]
    public partial class UnsignedItems : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 11 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 14 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Memorabilia.Web.Shared.PopConfirm>(1);
            __builder.AddAttribute(2, "Title", "Delete Memorabilia Item");
            __builder.AddAttribute(3, "ConfirmedChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 19 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
                                  Delete

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(4, (__value) => {
#nullable restore
#line 17 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
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
#line 22 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
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
            __builder.AddMarkupContent(16, @"<thead><tr><th>Item Type</th>
                <th>Condition</th>
                <th>Value</th>
                <th>Acquisition Type</th>
                <th>Acquisition Date</th>
                <th>Cost</th>
                <th>Place of Purchase</th>
                <th>Privacy Type</th>
                <th>Create Date</th>
                <th>Last Modified Date</th>
                <th></th>
                <th></th>
                <th></th></tr></thead>
        ");
            __builder.OpenElement(17, "tbody");
#nullable restore
#line 45 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
             foreach (var memorabiliaItem in _viewModel.MemorabiliaItems)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(18, "tr");
            __builder.OpenElement(19, "td");
#nullable restore
#line 48 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(20, memorabiliaItem.ItemTypeName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                    ");
            __builder.OpenElement(22, "td");
#nullable restore
#line 49 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(23, memorabiliaItem.ConditionName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                    ");
            __builder.OpenElement(25, "td");
#nullable restore
#line 50 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(26, memorabiliaItem.EstimatedValue?.ToString("c"));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                    ");
            __builder.OpenElement(28, "td");
#nullable restore
#line 51 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(29, memorabiliaItem.AcquisitionTypeName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                    ");
            __builder.OpenElement(31, "td");
#nullable restore
#line 52 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(32, memorabiliaItem.Acquisition.AcquiredDate?.ToString("MM-dd-yyyy"));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                    ");
            __builder.OpenElement(34, "td");
#nullable restore
#line 53 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(35, memorabiliaItem.Acquisition.Cost?.ToString("c"));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n                    ");
            __builder.OpenElement(37, "td");
#nullable restore
#line 54 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(38, memorabiliaItem.PurchaseTypeName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                    ");
            __builder.OpenElement(40, "td");
#nullable restore
#line 55 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(41, memorabiliaItem.PrivacyTypeName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n                    ");
            __builder.OpenElement(43, "td");
#nullable restore
#line 56 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(44, memorabiliaItem.CreateDate);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n                    ");
            __builder.OpenElement(46, "td");
#nullable restore
#line 57 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
__builder.AddContent(47, memorabiliaItem.LastModifiedDate);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n                    ");
            __builder.OpenElement(49, "td");
            __builder.OpenElement(50, "a");
            __builder.AddAttribute(51, "href", 
#nullable restore
#line 58 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
                                  $"Memorabilia/{memorabiliaItem.ItemTypeName}/Edit/{memorabiliaItem.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(52, "Details");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n                    ");
            __builder.OpenElement(54, "td");
            __builder.OpenElement(55, "a");
            __builder.AddAttribute(56, "href", 
#nullable restore
#line 59 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
                                  $"Memorabilia/Edit/{memorabiliaItem.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(57, "Edit");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                    ");
            __builder.OpenElement(59, "td");
            __builder.OpenElement(60, "button");
            __builder.AddAttribute(61, "class", "btn btn-danger");
            __builder.AddAttribute(62, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 60 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
                                                                    _ => ShowConfirm(memorabiliaItem.Id) 

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(63, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 62 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n    ");
            __builder.AddMarkupContent(65, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><div class=\"col-md-12\" style=\"text-align: center\"><a href=\"Memorabilia/Add\">Add Memorabilia</a></div></div></div>\r\n    <br>");
#nullable restore
#line 73 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 75 "C:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\UnsignedItems.razor"
       
    private PopConfirm _deleteDialog;
    private int _deletedItemId;
    private MemorabiliaItemsViewModel _viewModel;

    protected async Task Delete(bool confirm)
    {
        if (!confirm)
        {
            _deletedItemId = 0;
            return;
        }

        var itemToDelete = _viewModel.MemorabiliaItems.Single(item => item.Id == _deletedItemId);
        var viewModel = new SaveMemorabiliaItemViewModel(itemToDelete);
        viewModel.IsDeleted = true;

        var command = new SaveMemorabiliaItem.Command(viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);
        await OnInitializedAsync().ConfigureAwait(false);

        _toastService.ShowSuccess($"{itemToDelete.ItemTypeName} was deleted successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        var query = new GetMemorabiliaItems.Query(userId.Value);

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
