#pragma checksum "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ed21d5832092aff622d77c6a116e8163f6a2f92"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Admin.Teams
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
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
using Memorabilia.Application.Features.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
using Memorabilia.Application.Features.Admin.Franchise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
using Memorabilia.Application.Features.Admin.Sport;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
using Memorabilia.Application.Features.Admin.Team;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
using Memorabilia.Domain.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
using Memorabilia.Web.Controls.Franchise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
using Memorabilia.Web.Controls.SportLeagueLevel;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Teams/Add")]
    public partial class AddTeam : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 17 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
 if (_viewModel == null) 
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 20 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
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
#line 25 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
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
            __builder.AddMarkupContent(14, "<div class=\"col-lg-12\" style=\"text-align: center\"><img src=\"images/teams.jpg\" alt=\"Image\" height=\"150\" width=\"150\"></div>\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(15);
            __builder.AddAttribute(16, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 34 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                             _viewModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 34 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
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
                __builder2.AddMarkupContent(25, "<label for=\"sport\">Sport</label>\r\n                    ");
                __builder2.OpenElement(26, "select");
                __builder2.AddAttribute(27, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 39 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                       OnChangeSportLeagueLevel

#line default
#line hidden
#nullable disable
                ));
#nullable restore
#line 40 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                         foreach (var sportLeagueLevel in SportLeagueLevel.All)
                        {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(28, "option");
                __builder2.AddAttribute(29, "value", 
#nullable restore
#line 42 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                            sportLeagueLevel.Id

#line default
#line hidden
#nullable disable
                );
#nullable restore
#line 42 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
__builder2.AddContent(30, sportLeagueLevel.Name);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
#nullable restore
#line 43 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                        }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(31, "\r\n                ");
                __builder2.OpenElement(32, "div");
                __builder2.AddAttribute(33, "class", "form-group");
                __builder2.AddMarkupContent(34, "<label for=\"franchise\">Franchise</label>\r\n                    ");
                __builder2.OpenComponent<Memorabilia.Web.Controls.Franchise._FranchiseDropDown>(35);
                __builder2.AddAttribute(36, "SportLeagueLevel", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Memorabilia.Domain.Constants.SportLeagueLevel>(
#nullable restore
#line 50 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                           _sportLeagueLevel

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(37, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 48 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                      _viewModel.FranchiseId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(38, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.FranchiseId = __value, _viewModel.FranchiseId))));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n                ");
                __builder2.OpenElement(40, "div");
                __builder2.AddAttribute(41, "class", "form-group");
                __builder2.AddMarkupContent(42, "<label for=\"name\">Name</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(43);
                __builder2.AddAttribute(44, "id", "name");
                __builder2.AddAttribute(45, "class", "form-control");
                __builder2.AddAttribute(46, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 54 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                      _viewModel.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(47, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Name = __value, _viewModel.Name))));
                __builder2.AddAttribute(48, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Name));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(49, "\r\n                ");
                __builder2.OpenElement(50, "div");
                __builder2.AddAttribute(51, "class", "form-group");
                __builder2.AddMarkupContent(52, "<label for=\"location\">Location</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(53);
                __builder2.AddAttribute(54, "id", "location");
                __builder2.AddAttribute(55, "class", "form-control");
                __builder2.AddAttribute(56, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 58 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                          _viewModel.Location

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(57, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Location = __value, _viewModel.Location))));
                __builder2.AddAttribute(58, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Location));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(59, "\r\n                ");
                __builder2.OpenElement(60, "div");
                __builder2.AddAttribute(61, "class", "form-group");
                __builder2.AddMarkupContent(62, "<label for=\"nickname\">Nickname</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(63);
                __builder2.AddAttribute(64, "id", "nickname");
                __builder2.AddAttribute(65, "class", "form-control");
                __builder2.AddAttribute(66, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 62 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                          _viewModel.Nickname

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(67, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Nickname = __value, _viewModel.Nickname))));
                __builder2.AddAttribute(68, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Nickname));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(69, "\r\n                ");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "class", "form-group");
                __builder2.AddMarkupContent(72, "<label for=\"abbreviation\">Abbreviation</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(73);
                __builder2.AddAttribute(74, "id", "abbreviation");
                __builder2.AddAttribute(75, "class", "form-control");
                __builder2.AddAttribute(76, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 66 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                              _viewModel.Abbreviation

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(77, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.Abbreviation = __value, _viewModel.Abbreviation))));
                __builder2.AddAttribute(78, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.Abbreviation));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(79, "\r\n                ");
                __builder2.OpenElement(80, "div");
                __builder2.AddAttribute(81, "class", "form-group");
                __builder2.AddMarkupContent(82, "<label for=\"beginYear\">Begin Year</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.Admin.Teams.AddTeam.TypeInference.CreateInputNumber_0(__builder2, 83, 84, "beginYear", 85, "form-control", 86, 
#nullable restore
#line 70 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                             _viewModel.BeginYear

#line default
#line hidden
#nullable disable
                , 87, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.BeginYear = __value, _viewModel.BeginYear)), 88, () => _viewModel.BeginYear);
                __builder2.CloseElement();
                __builder2.AddMarkupContent(89, "\r\n                ");
                __builder2.OpenElement(90, "div");
                __builder2.AddAttribute(91, "class", "form-group");
                __builder2.AddMarkupContent(92, "<label for=\"endYear\">End Year</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.Admin.Teams.AddTeam.TypeInference.CreateInputNumber_1(__builder2, 93, 94, "endYear", 95, "form-control", 96, 
#nullable restore
#line 74 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                           _viewModel.EndYear

#line default
#line hidden
#nullable disable
                , 97, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.EndYear = __value, _viewModel.EndYear)), 98, () => _viewModel.EndYear);
                __builder2.CloseElement();
                __builder2.AddMarkupContent(99, "\r\n                ");
                __builder2.OpenElement(100, "div");
                __builder2.AddAttribute(101, "class", "text-right");
                __builder2.OpenElement(102, "button");
                __builder2.AddAttribute(103, "type", "submit");
                __builder2.AddAttribute(104, "class", "btn btn-primary");
                __builder2.AddAttribute(105, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 77 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                                              ()=> _continue = true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(106, "Save & Continue");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(107, "\r\n                    ");
                __builder2.AddMarkupContent(108, "<button type=\"submit\" class=\"btn btn-primary\">Save & Exit</button>\r\n                    ");
                __builder2.OpenElement(109, "button");
                __builder2.AddAttribute(110, "type", "button");
                __builder2.AddAttribute(111, "class", "btn btn-secondary");
                __builder2.AddAttribute(112, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 79 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
                                                                                _ => _navigation.NavigateTo("Teams")

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(113, "Cancel");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n        ");
            __builder.AddMarkupContent(115, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><a href=\"Teams\">Back</a></div></div>\r\n        <br>");
            __builder.CloseElement();
#nullable restore
#line 90 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 92 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Admin\Teams\AddTeam.razor"
       
    private bool _continue;
    private SportLeagueLevel _sportLeagueLevel;
    private SaveTeamViewModel _viewModel = new SaveTeamViewModel();

    protected async Task HandleValidSubmit()
    {
        var command = new SaveTeam.Command(_viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);

        var nextStep = _sportLeagueLevel == SportLeagueLevel.MajorLeagueBaseball ? "Division" : "Conference";

        var url = _continue ? $"Team/{nextStep}/Add/{command.Id}/{_sportLeagueLevel.Id}" : "Teams";

        _navigation.NavigateTo(url);

        _toastService.ShowSuccess("Team was added successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        _sportLeagueLevel = SportLeagueLevel.MajorLeagueBaseball;
    }

    private void OnChangeSportLeagueLevel(ChangeEventArgs args)
    {
        _sportLeagueLevel = SportLeagueLevel.Find(int.Parse(args.Value.ToString()));
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
namespace __Blazor.Memorabilia.Web.Pages.Admin.Teams.AddTeam
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputNumber_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
