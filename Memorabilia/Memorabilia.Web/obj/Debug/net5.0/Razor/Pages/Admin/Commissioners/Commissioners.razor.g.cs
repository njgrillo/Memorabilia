#pragma checksum "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b3d665ad7f2e076f25478e3dfd89f22d8ab4cf1"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Admin.Commissioners
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Demo.Framework.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Framework.Extension;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Domain.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
using Memorabilia.Application.Features.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
using Memorabilia.Application.Features.Admin.Commissioner;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Commissioners")]
    public partial class Commissioners : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 12 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 15 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Memorabilia.Web.Shared.PopConfirm>(1);
            __builder.AddAttribute(2, "Title", "Delete Commissioner");
            __builder.AddAttribute(3, "ConfirmedChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 20 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
                                  Delete

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(4, (__value) => {
#nullable restore
#line 18 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
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
#line 23 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
__builder.AddContent(12, _viewModel.PageTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n    <br>\r\n    ");
            __builder.OpenComponent<Memorabilia.Web.Controls._Table<CommissionerViewModel>>(14);
            __builder.AddAttribute(15, "Items", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<CommissionerViewModel>>(
#nullable restore
#line 27 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
                   _viewModel.Commissioners

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "ItemsPerPage", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 28 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
                          10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "HeaderTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(18, "<th scope=\"col\">Sport</th>\r\n            ");
                __builder2.AddMarkupContent(19, "<th scope=\"col\">Name</th>\r\n            ");
                __builder2.AddMarkupContent(20, "<th scope=\"col\">Begin Year</th>\r\n            ");
                __builder2.AddMarkupContent(21, "<th scope=\"col\">End Year</th>\r\n            <th scope=\"col\"></th>\r\n            <th scope=\"col\"></th>");
            }
            ));
            __builder.AddAttribute(22, "RowTemplate", (Microsoft.AspNetCore.Components.RenderFragment<CommissionerViewModel>)((context) => (__builder2) => {
                __builder2.OpenElement(23, "td");
#nullable restore
#line 39 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
__builder2.AddContent(24, context.SportLeagueLevelName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n            ");
                __builder2.OpenElement(26, "td");
#nullable restore
#line 40 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
__builder2.AddContent(27, context.Person.DisplayName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n            ");
                __builder2.OpenElement(29, "td");
#nullable restore
#line 41 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
__builder2.AddContent(30, context.BeginYear?.ToString());

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n            ");
                __builder2.OpenElement(32, "td");
#nullable restore
#line 42 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
__builder2.AddContent(33, context.EndYear?.ToString());

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(34, "\r\n            ");
                __builder2.OpenElement(35, "td");
                __builder2.OpenComponent<Memorabilia.Web.Controls._Tooltip>(36);
                __builder2.AddAttribute(37, "Text", "Edit");
                __builder2.AddAttribute(38, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(39, "img");
                    __builder3.AddAttribute(40, "class", "can-click");
                    __builder3.AddAttribute(41, "src", "images/pencil.png");
                    __builder3.AddAttribute(42, "height", "25");
                    __builder3.AddAttribute(43, "width", "25");
                    __builder3.AddAttribute(44, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 49 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
                                        _ => _navigation.NavigateTo($"{_viewModel.RoutePrefix}/Edit/{context.Id}")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(45, "\r\n            ");
                __builder2.OpenElement(46, "td");
                __builder2.OpenComponent<Memorabilia.Web.Controls._Tooltip>(47);
                __builder2.AddAttribute(48, "Text", "Delete");
                __builder2.AddAttribute(49, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(50, "img");
                    __builder3.AddAttribute(51, "class", "can-click");
                    __builder3.AddAttribute(52, "src", "images/trash.png");
                    __builder3.AddAttribute(53, "height", "25");
                    __builder3.AddAttribute(54, "width", "25");
                    __builder3.AddAttribute(55, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 58 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
                                        _ => ShowConfirm(context.Id)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(56, "\r\n    ");
            __builder.OpenElement(57, "div");
            __builder.AddAttribute(58, "class", "row");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "col-md-12");
            __builder.AddAttribute(61, "style", "text-align: center");
            __builder.OpenElement(62, "div");
            __builder.AddAttribute(63, "class", "col-md-12");
            __builder.AddAttribute(64, "style", "text-align: center");
            __builder.OpenElement(65, "a");
            __builder.AddAttribute(66, "href", "Commissioners/Add");
            __builder.AddContent(67, "Add ");
#nullable restore
#line 66 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
__builder.AddContent(68, _viewModel.ItemTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n    <br>");
#nullable restore
#line 71 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 73 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Commissioners\Commissioners.razor"
       
    private PopConfirm _deleteDialog;
    private int _deletedItemId;
    private CommissionersViewModel _viewModel;

    protected async Task Delete(bool confirm)
    {
        if (!confirm)
        {
            _deletedItemId = 0;
            return;
        }

        var deletedItem = _viewModel.Commissioners.Single(Commissioner => Commissioner.Id == _deletedItemId);
        var viewModel = new SaveCommissionerViewModel(deletedItem);
        viewModel.IsDeleted = true;

        var command = new SaveCommissioner.Command(viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);

        _viewModel.Commissioners.Remove(deletedItem);

        _toastService.ShowSuccess($"{_viewModel.ItemTitle} was deleted successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        var query = new GetCommissioners.Query();

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
