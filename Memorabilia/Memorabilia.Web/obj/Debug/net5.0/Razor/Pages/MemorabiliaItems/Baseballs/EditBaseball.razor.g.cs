#pragma checksum "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfbfd655e3917662fd6f0ef3a30f2f98f9752b0c"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.MemorabiliaItems.Baseballs
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
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Application.Features.Memorabilia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Application.Features.Memorabilia.Baseball;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Domain.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Web.Controls.Baseball;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Web.Controls.ItemTypeBrand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Web.Controls.ItemTypeSize;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Web.Controls.Commissioner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Web.Controls.Person;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Web.Controls.Team;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Memorabilia/Baseball/Edit/{memorabiliaId:int}")]
    public partial class EditBaseball : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 19 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 22 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
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
#line 27 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
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
            __builder.AddMarkupContent(14, "<div class=\"col-lg-12\" style=\"text-align: center\"><img src=\"images/itemtypes.jpg\" alt=\"Image\" height=\"150\" width=\"150\"></div>            \r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(15);
            __builder.AddAttribute(16, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 36 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                             _viewModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 36 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
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
                __builder2.AddMarkupContent(25, "<label for=\"brand\">Brand</label>\r\n                    ");
                __builder2.OpenComponent<Memorabilia.Web.Controls.ItemTypeBrand._ItemTypeBrandDropDown>(26);
                __builder2.AddAttribute(27, "ItemType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Memorabilia.Domain.Constants.ItemType>(
#nullable restore
#line 43 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                       ItemType.Baseball

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 41 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                          _viewModel.BrandId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(29, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.BrandId = __value, _viewModel.BrandId))));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "                \r\n                ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "form-group");
                __builder2.AddAttribute(33, "hidden", 
#nullable restore
#line 45 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                  !_viewModel.DisplayBaseballType

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(34, "<label for=\"baseballType\">Baseball Type</label>\r\n                    ");
                __builder2.OpenComponent<Memorabilia.Web.Controls.Baseball._BaseballTypeDropDown>(35);
                __builder2.AddAttribute(36, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 47 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                         _viewModel.BaseballTypeId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(37, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.BaseballTypeId = __value, _viewModel.BaseballTypeId))));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(38, "                 \r\n                ");
                __builder2.OpenElement(39, "div");
                __builder2.AddAttribute(40, "class", "form-group");
                __builder2.AddAttribute(41, "hidden", 
#nullable restore
#line 50 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                  !_viewModel.DisplayBaseballTypeYear

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(42, "<label for=\"year\">Year</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.MemorabiliaItems.Baseballs.EditBaseball.TypeInference.CreateInputNumber_0(__builder2, 43, 44, "year", 45, "form-control", 46, 
#nullable restore
#line 52 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                                             _viewModel.BaseballTypeYear

#line default
#line hidden
#nullable disable
                , 47, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.BaseballTypeYear = __value, _viewModel.BaseballTypeYear)), 48, () => _viewModel.BaseballTypeYear);
                __builder2.CloseElement();
                __builder2.AddMarkupContent(49, " \r\n                ");
                __builder2.OpenElement(50, "div");
                __builder2.AddAttribute(51, "class", "form-group");
                __builder2.AddAttribute(52, "hidden", 
#nullable restore
#line 54 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                  !_viewModel.DisplayBaseballTypeAnniversary

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(53, "<label for=\"anniversary\">Anniversary</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(54);
                __builder2.AddAttribute(55, "id", "anniversary");
                __builder2.AddAttribute(56, "class", "form-control");
                __builder2.AddAttribute(57, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 56 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                                                  _viewModel.BaseballTypeAnniversary

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(58, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.BaseballTypeAnniversary = __value, _viewModel.BaseballTypeAnniversary))));
                __builder2.AddAttribute(59, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => _viewModel.BaseballTypeAnniversary));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(60, "  \r\n                ");
                __builder2.OpenElement(61, "div");
                __builder2.AddAttribute(62, "class", "form-group");
                __builder2.AddMarkupContent(63, "<label for=\"commissioner\">Commissioner</label>\r\n                    ");
                __builder2.OpenComponent<Memorabilia.Web.Controls.Commissioner._CommissionerDropDown>(64);
                __builder2.AddAttribute(65, "Sport", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Memorabilia.Domain.Constants.Sport>(
#nullable restore
#line 62 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                   Sport.Baseball

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(66, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 60 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                         _viewModel.CommissionerId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(67, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.CommissionerId = __value, _viewModel.CommissionerId))));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(68, "\r\n                ");
                __builder2.OpenElement(69, "div");
                __builder2.AddAttribute(70, "class", "form-group");
                __builder2.AddMarkupContent(71, "<label for=\"size\">Size</label>\r\n                    ");
                __builder2.OpenComponent<Memorabilia.Web.Controls.ItemTypeSize._ItemTypeSizeDropDown>(72);
                __builder2.AddAttribute(73, "ItemType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Memorabilia.Domain.Constants.ItemType>(
#nullable restore
#line 68 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                      ItemType.Baseball

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(74, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 66 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                         _viewModel.SizeId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(75, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.SizeId = __value, _viewModel.SizeId))));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(76, "                \r\n                ");
                __builder2.OpenElement(77, "div");
                __builder2.AddAttribute(78, "class", "form-group");
                __builder2.OpenElement(79, "input");
                __builder2.AddAttribute(80, "type", "checkbox");
                __builder2.AddAttribute(81, "checked", 
#nullable restore
#line 79 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                     _viewModel.HasTeam

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(82, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 79 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                                                    eventArgs => { TeamsCheckboxClicked(eventArgs.Value); }

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(83, "\r\n                    ");
                __builder2.AddMarkupContent(84, "<label for=\"teams\">Associate Baseball with a Team</label>\r\n                    ");
                __builder2.OpenElement(85, "div");
                __builder2.AddAttribute(86, "class", "form-group");
                __builder2.AddAttribute(87, "hidden", 
#nullable restore
#line 81 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                      !_displayTeams

#line default
#line hidden
#nullable disable
                );
                __builder2.OpenComponent<Memorabilia.Web.Controls.Team._TeamDropDown>(88);
                __builder2.AddAttribute(89, "Sport", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Memorabilia.Domain.Constants.Sport>(
#nullable restore
#line 84 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                               Sport.Baseball

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(90, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 82 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
                                                     _viewModel.TeamId

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(91, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.TeamId = __value, _viewModel.TeamId))));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(92, "                             \r\n                ");
                __builder2.AddMarkupContent(93, "<div class=\"text-right\"><button type=\"submit\" class=\"btn btn-primary\">Save</button></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n        ");
            __builder.AddMarkupContent(95, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><a href=\"Memorabilia/UnsignedItems\">Back</a></div></div>\r\n        <br>");
            __builder.CloseElement();
#nullable restore
#line 99 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 101 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
       
    [Parameter]
    public int MemorabiliaId { get; set; }  

    private bool _displayPeople;
    private bool _displayTeams;
    private SaveBaseballViewModel _viewModel = new SaveBaseballViewModel();

    protected async Task HandleValidSubmit()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        var command = new SaveBaseball.Command(_viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);

        _navigation.NavigateTo("Memorabilia");

        _toastService.ShowSuccess("Baseball Details were saved successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");        

        var query = new GetBaseball.Query(MemorabiliaId);
        var baseballViewModel = await _queryRouter.Send(query).ConfigureAwait(false);

        if (baseballViewModel.MemorabiliaBrand == null)
        {
            _navigation.NavigateTo($"Memorabilia/Baseball/Add/{MemorabiliaId}");
            return;
        }    

        _viewModel = new SaveBaseballViewModel(baseballViewModel);  
        
        _displayPeople = _viewModel.HasPerson;
        _displayTeams = _viewModel.HasTeam;
    }  

    private void PersonCheckboxClicked(object isChecked)
    {     
        _displayPeople = (bool)isChecked;

        if (!_displayPeople)
            _viewModel.Person = null;

        StateHasChanged();
    } 

    public void TeamsCheckboxClicked(object isChecked)
    {
        _displayTeams = (bool)isChecked;

        if (!_displayTeams)
            _viewModel.TeamId = 0;

        StateHasChanged();
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
namespace __Blazor.Memorabilia.Web.Pages.MemorabiliaItems.Baseballs.EditBaseball
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
    }
}
#pragma warning restore 1591
