#pragma checksum "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "835aba33cae28375d9386fa7f00743205f9a6ef4"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.User
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
using Memorabilia.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Memorabilia.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
using Memorabilia.Application.Features.User.Register;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 9 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 12 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
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
#line 17 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
__builder.AddContent(7, _viewModel.PageTitle);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    <br>\r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "row");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(11);
            __builder.AddAttribute(12, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 22 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                         _viewModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 22 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                    HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(15);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\r\n            ");
                __builder2.OpenElement(17, "div");
                __builder2.AddAttribute(18, "class", "form-group");
                __builder2.AddMarkupContent(19, "<label for=\"username\">User Name</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(20);
                __builder2.AddAttribute(21, "id", "username");
                __builder2.AddAttribute(22, "class", "form-control");
                __builder2.AddAttribute(23, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 26 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                      _viewModel.Username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Username = __value, _viewModel.Username))));
                __builder2.AddAttribute(25, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Username));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n            ");
                __builder2.OpenElement(27, "div");
                __builder2.AddAttribute(28, "class", "form-group");
                __builder2.AddMarkupContent(29, "<label for=\"password\">Password</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(30);
                __builder2.AddAttribute(31, "id", "password");
                __builder2.AddAttribute(32, "type", "password");
                __builder2.AddAttribute(33, "class", "form-control");
                __builder2.AddAttribute(34, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                                      _viewModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Password = __value, _viewModel.Password))));
                __builder2.AddAttribute(36, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Password));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n            ");
                __builder2.OpenElement(38, "div");
                __builder2.AddAttribute(39, "class", "form-group");
                __builder2.AddMarkupContent(40, "<label for=\"confirmPassword\">Confirm Password</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(41);
                __builder2.AddAttribute(42, "id", "confirmPassword");
                __builder2.AddAttribute(43, "type", "password");
                __builder2.AddAttribute(44, "class", "form-control");
                __builder2.AddAttribute(45, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 34 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                                             _viewModel.ConfirmPassword

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(46, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.ConfirmPassword = __value, _viewModel.ConfirmPassword))));
                __builder2.AddAttribute(47, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.ConfirmPassword));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(48, "\r\n            ");
                __builder2.OpenElement(49, "div");
                __builder2.AddAttribute(50, "class", "form-group");
                __builder2.AddMarkupContent(51, "<label for=\"firstName\">First Name</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(52);
                __builder2.AddAttribute(53, "id", "firstName");
                __builder2.AddAttribute(54, "class", "form-control");
                __builder2.AddAttribute(55, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 38 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                       _viewModel.FirstName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(56, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.FirstName = __value, _viewModel.FirstName))));
                __builder2.AddAttribute(57, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.FirstName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(58, "\r\n            ");
                __builder2.OpenElement(59, "div");
                __builder2.AddAttribute(60, "class", "form-group");
                __builder2.AddMarkupContent(61, "<label for=\"lastName\">Last Name</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(62);
                __builder2.AddAttribute(63, "id", "lastName");
                __builder2.AddAttribute(64, "class", "form-control");
                __builder2.AddAttribute(65, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 42 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                      _viewModel.LastName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(66, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.LastName = __value, _viewModel.LastName))));
                __builder2.AddAttribute(67, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.LastName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(68, "\r\n            ");
                __builder2.OpenElement(69, "div");
                __builder2.AddAttribute(70, "class", "form-group");
                __builder2.AddMarkupContent(71, "<label for=\"emailAddress\">Email Address</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(72);
                __builder2.AddAttribute(73, "id", "emailAddress");
                __builder2.AddAttribute(74, "class", "form-control");
                __builder2.AddAttribute(75, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 46 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                          _viewModel.EmailAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(76, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.EmailAddress = __value, _viewModel.EmailAddress))));
                __builder2.AddAttribute(77, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.EmailAddress));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(78, "\r\n            ");
                __builder2.OpenElement(79, "div");
                __builder2.AddAttribute(80, "class", "form-group");
                __builder2.AddMarkupContent(81, "<label for=\"phoneNumber\">Phone Number</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(82);
                __builder2.AddAttribute(83, "id", "phoneNumber");
                __builder2.AddAttribute(84, "class", "form-control");
                __builder2.AddAttribute(85, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 50 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
                                                         _viewModel.Phone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(86, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Phone = __value, _viewModel.Phone))));
                __builder2.AddAttribute(87, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Phone));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(88, "\r\n            ");
                __builder2.AddMarkupContent(89, "<div class=\"text-right\"><button type=\"submit\" class=\"btn btn-primary\">Save</button></div>\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(90);
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 58 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 60 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\User\Register.razor"
       
    private SaveUserViewModel _viewModel = new SaveUserViewModel();

    protected EditContext MyEditContext { get; set; }

    protected async Task HandleValidSubmit()
    {
        var command = new AddUser.Command(_viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);

        //Set user id in local storage

        _navigation.NavigateTo("Home");
    }

    protected override void OnInitialized()
    {
        MyEditContext = new EditContext(_viewModel);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigation { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CommandRouter _commandRouter { get; set; }
    }
}
#pragma warning restore 1591
