#pragma checksum "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daddda1fedd6c132fcf8e4c9220b4ac66d6c2b27"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Admin.People
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
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
using Memorabilia.Application.Features.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
using Memorabilia.Application.Features.Admin.Person;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/People")]
    public partial class People : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 12 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 15 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Memorabilia.Web.Shared.PopConfirm>(1);
            __builder.AddAttribute(2, "Title", "Delete Person");
            __builder.AddAttribute(3, "ConfirmedChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 20 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
                                  Delete

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(4, (__value) => {
#nullable restore
#line 18 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
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
#line 23 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder.AddContent(12, _viewModel.PageTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n    <br>\r\n    ");
            __builder.OpenComponent<Memorabilia.Web.Controls._Table<PersonViewModel>>(14);
            __builder.AddAttribute(15, "Items", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<PersonViewModel>>(
#nullable restore
#line 27 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
                   _viewModel.People

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "ItemsPerPage", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 28 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
                          10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "HeaderTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(18, "<th scope=\"col\">Display Name</th>\r\n            ");
                __builder2.AddMarkupContent(19, "<th scope=\"col\">First Name</th>\r\n            ");
                __builder2.AddMarkupContent(20, "<th scope=\"col\">Last Name</th>\r\n            ");
                __builder2.AddMarkupContent(21, "<th scope=\"col\">Middle Name</th>\r\n            ");
                __builder2.AddMarkupContent(22, "<th scope=\"col\">Suffix</th>\r\n            ");
                __builder2.AddMarkupContent(23, "<th scope=\"col\">Nickname</th>\r\n            ");
                __builder2.AddMarkupContent(24, "<th scope=\"col\">Legal Name</th>\r\n            ");
                __builder2.AddMarkupContent(25, "<th scope=\"col\">Birth Date</th>\r\n            ");
                __builder2.AddMarkupContent(26, "<th scope=\"col\">Death Date</th>\r\n            <th scope=\"col\"></th>\r\n            <th scope=\"col\"></th>");
            }
            ));
            __builder.AddAttribute(27, "RowTemplate", (Microsoft.AspNetCore.Components.RenderFragment<PersonViewModel>)((context) => (__builder2) => {
                __builder2.OpenElement(28, "td");
#nullable restore
#line 44 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(29, context.DisplayName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n            ");
                __builder2.OpenElement(31, "td");
#nullable restore
#line 45 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(32, context.FirstName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n            ");
                __builder2.OpenElement(34, "td");
#nullable restore
#line 46 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(35, context.LastName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(36, "\r\n            ");
                __builder2.OpenElement(37, "td");
#nullable restore
#line 47 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(38, context.MiddleName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n            ");
                __builder2.OpenElement(40, "td");
#nullable restore
#line 48 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(41, context.Suffix);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n            ");
                __builder2.OpenElement(43, "td");
#nullable restore
#line 49 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(44, context.Nickname);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(45, "\r\n            ");
                __builder2.OpenElement(46, "td");
#nullable restore
#line 50 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(47, context.LegalName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(48, "\r\n            ");
                __builder2.OpenElement(49, "td");
#nullable restore
#line 51 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(50, context.BirthDate);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(51, "\r\n            ");
                __builder2.OpenElement(52, "td");
#nullable restore
#line 52 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
__builder2.AddContent(53, context.DeathDate);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(54, "\r\n            ");
                __builder2.OpenElement(55, "td");
                __builder2.OpenComponent<Memorabilia.Web.Controls._Tooltip>(56);
                __builder2.AddAttribute(57, "Text", "Edit");
                __builder2.AddAttribute(58, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(59, "img");
                    __builder3.AddAttribute(60, "class", "can-click");
                    __builder3.AddAttribute(61, "src", "images/pencil.png");
                    __builder3.AddAttribute(62, "height", "25");
                    __builder3.AddAttribute(63, "width", "25");
                    __builder3.AddAttribute(64, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 59 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
                                        _ => _navigation.NavigateTo($"People/Edit/{context.Id}")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n            ");
                __builder2.OpenElement(66, "td");
                __builder2.OpenComponent<Memorabilia.Web.Controls._Tooltip>(67);
                __builder2.AddAttribute(68, "Text", "Delete");
                __builder2.AddAttribute(69, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(70, "img");
                    __builder3.AddAttribute(71, "class", "can-click");
                    __builder3.AddAttribute(72, "src", "images/trash.png");
                    __builder3.AddAttribute(73, "height", "25");
                    __builder3.AddAttribute(74, "width", "25");
                    __builder3.AddAttribute(75, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 68 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
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
            __builder.AddMarkupContent(76, "\r\n    ");
            __builder.AddMarkupContent(77, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><div class=\"col-md-12\" style=\"text-align: center\"><a href=\"People/Add\">Add Person</a></div></div></div>\r\n    <br>");
#nullable restore
#line 81 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 83 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\People\People.razor"
       
    private PopConfirm _deleteDialog;
    private int _deletedItemId;
    private PeopleViewModel _viewModel;

    protected async Task Delete(bool confirm)
    {
        if (!confirm)
        {
            _deletedItemId = 0;
            return;
        }

        var deletedItem = _viewModel.People.Single(person => person.Id == _deletedItemId);
        var viewModel = new SavePersonViewModel(deletedItem);
        viewModel.IsDeleted = true;

        var command = new SavePerson.Command(viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);
        
        _viewModel.People.Remove(deletedItem);

        _toastService.ShowSuccess($"{_viewModel.ItemTitle} was deleted successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        var query = new GetPeople.Query();

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
