#pragma checksum "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1db904369e165c9767d3681a3625f2eb5dbf484"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Admin.Colors
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
#line 3 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
using Memorabilia.Application.Features.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
using Memorabilia.Application.Features.Admin.Color;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Colors/Add")]
    public partial class AddColor : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 11 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 14 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-md-12");
            __builder.AddAttribute(5, "style", "text-align: center");
            __builder.OpenElement(6, "h1");
#nullable restore
#line 19 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
__builder.AddContent(7, _viewModel.PageTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    <br>\r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "style", "border: 1px solid black; margin-top: 2%; margin-bottom: 2%; margin-left: 2%; margin-right: 2%;");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "row");
            __builder.AddAttribute(13, "style", "margin-top: 2%; margin-bottom: 2%; margin-left: 1%; margin-right: 1%;");
            __builder.AddMarkupContent(14, "<div class=\"col-lg-12\" style=\"text-align: center\"><img src=\"images/colors.png\" alt=\"Image\" height=\"150\" width=\"150\"></div>\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(15);
            __builder.AddAttribute(16, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 28 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
                             _viewModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 28 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
                                                        HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(19);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(20, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(21);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\r\n                ");
                __builder2.OpenElement(23, "div");
                __builder2.AddAttribute(24, "class", "form-group");
                __builder2.AddMarkupContent(25, "<label for=\"name\">Name</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(26);
                __builder2.AddAttribute(27, "id", "name");
                __builder2.AddAttribute(28, "class", "form-control");
                __builder2.AddAttribute(29, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
                                                      _viewModel.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(30, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Name = __value, _viewModel.Name))));
                __builder2.AddAttribute(31, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Name));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(32, "\r\n                ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "form-group");
                __builder2.AddMarkupContent(35, "<label for=\"abbreviation\">Abbreviation</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(36);
                __builder2.AddAttribute(37, "id", "abbreviation");
                __builder2.AddAttribute(38, "class", "form-control");
                __builder2.AddAttribute(39, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 37 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
                                                              _viewModel.Abbreviation

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Abbreviation = __value, _viewModel.Abbreviation))));
                __builder2.AddAttribute(41, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Abbreviation));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n                ");
                __builder2.AddMarkupContent(43, "<div class=\"text-right\"><button type=\"submit\" class=\"btn btn-primary\">Save</button></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n        ");
            __builder.AddMarkupContent(45, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><a href=\"Colors\">Back</a></div></div>\r\n        <br>");
            __builder.CloseElement();
#nullable restore
#line 51 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Colors\AddColor.razor"
       
    private SaveDomainViewModel _viewModel = new SaveDomainViewModel();

    protected async Task HandleValidSubmit()
    {
        var command = new SaveColor.Command(_viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);

        _navigation.NavigateTo("Colors");

        _toastService.ShowSuccess("Color was added successfully!", _viewModel.PageTitle);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService _toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CommandRouter _commandRouter { get; set; }
    }
}
#pragma warning restore 1591
