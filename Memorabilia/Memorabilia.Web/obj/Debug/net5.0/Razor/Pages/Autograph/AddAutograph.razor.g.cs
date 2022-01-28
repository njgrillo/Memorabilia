#pragma checksum "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "680f2e4ebbe546ecf07f6e2aa9730f9aeb877f9d"
// <auto-generated/>
#pragma warning disable 1591
namespace Memorabilia.Web.Pages.Autograph
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
#line 4 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
using Memorabilia.Application.Features.Admin.ItemTypeSpot;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
using Memorabilia.Application.Features.Admin.Person;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
using Memorabilia.Application.Features.Autograph;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
using Memorabilia.Application.Features.Memorabilia;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Autographs/Add")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/Autographs/Add/{memorabiliaId:int}")]
    public partial class AddAutograph : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 15 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
 if (_viewModel == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 18 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
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
#line 23 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
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
#line 32 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                             _viewModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 32 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
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
                __builder2.AddMarkupContent(25, "<label for=\"person\">Person</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.Autograph.AddAutograph.TypeInference.CreateInputSelect_0(__builder2, 26, 27, "person", 28, "form-control", 29, 
#nullable restore
#line 37 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                                          _viewModel.PersonId

#line default
#line hidden
#nullable disable
                , 30, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.PersonId = __value, _viewModel.PersonId)), 31, () => _viewModel.PersonId, 32, (__builder3) => {
#nullable restore
#line 38 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                         foreach (var person in _people)
                        {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(33, "option");
                    __builder3.AddAttribute(34, "value", 
#nullable restore
#line 40 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                            person.Id

#line default
#line hidden
#nullable disable
                    );
#nullable restore
#line 40 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
__builder3.AddContent(35, person.FullName);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
#nullable restore
#line 41 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                        }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(36, "\r\n                ");
                __builder2.OpenElement(37, "div");
                __builder2.AddAttribute(38, "class", "form-group");
                __builder2.AddMarkupContent(39, "<label for=\"condition\">Condition</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.Autograph.AddAutograph.TypeInference.CreateInputSelect_1(__builder2, 40, 41, "condition", 42, "form-control", 43, 
#nullable restore
#line 46 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                                             _viewModel.ConditionId

#line default
#line hidden
#nullable disable
                , 44, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.ConditionId = __value, _viewModel.ConditionId)), 45, () => _viewModel.ConditionId, 46, (__builder3) => {
#nullable restore
#line 47 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                         foreach (var condition in Domain.Constants.Condition.All)
                        {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(47, "option");
                    __builder3.AddAttribute(48, "value", 
#nullable restore
#line 49 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                            condition.Id

#line default
#line hidden
#nullable disable
                    );
#nullable restore
#line 49 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
__builder3.AddContent(49, condition.Name);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
#nullable restore
#line 50 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                        }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n                ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "class", "form-group");
                __builder2.AddMarkupContent(53, "<label for=\"writingInstrument\">Writing Instrument</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.Autograph.AddAutograph.TypeInference.CreateInputSelect_2(__builder2, 54, 55, "writingInstrument", 56, "form-control", 57, 
#nullable restore
#line 55 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                                                     _viewModel.WritingInstrumentId

#line default
#line hidden
#nullable disable
                , 58, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.WritingInstrumentId = __value, _viewModel.WritingInstrumentId)), 59, () => _viewModel.WritingInstrumentId, 60, (__builder3) => {
#nullable restore
#line 56 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                         foreach (var writingInstrument in Domain.Constants.WritingInstrument.All)
                        {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(61, "option");
                    __builder3.AddAttribute(62, "value", 
#nullable restore
#line 58 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                            writingInstrument.Id

#line default
#line hidden
#nullable disable
                    );
#nullable restore
#line 58 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
__builder3.AddContent(63, writingInstrument.Name);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
#nullable restore
#line 59 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                        }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(64, "\r\n                ");
                __builder2.OpenElement(65, "div");
                __builder2.AddAttribute(66, "class", "form-group");
                __builder2.AddMarkupContent(67, "<label for=\"color\">Color</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.Autograph.AddAutograph.TypeInference.CreateInputSelect_3(__builder2, 68, 69, "color", 70, "form-control", 71, 
#nullable restore
#line 64 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                                         _viewModel.ColorId

#line default
#line hidden
#nullable disable
                , 72, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.ColorId = __value, _viewModel.ColorId)), 73, () => _viewModel.ColorId, 74, (__builder3) => {
#nullable restore
#line 65 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                         foreach (var color in Domain.Constants.Color.All)
                        {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(75, "option");
                    __builder3.AddAttribute(76, "value", 
#nullable restore
#line 67 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                            color.Id

#line default
#line hidden
#nullable disable
                    );
#nullable restore
#line 67 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
__builder3.AddContent(77, color.Name);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
#nullable restore
#line 68 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                        }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(78, "\r\n                ");
                __builder2.OpenElement(79, "div");
                __builder2.AddAttribute(80, "class", "form-group");
                __builder2.AddAttribute(81, "hidden", 
#nullable restore
#line 71 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                                  !_displaySpots

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(82, "<label for=\"spot\">Spot</label>\r\n                    ");
                __Blazor.Memorabilia.Web.Pages.Autograph.AddAutograph.TypeInference.CreateInputSelect_4(__builder2, 83, 84, "spot", 85, "form-control", 86, 
#nullable restore
#line 73 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                                        _viewModel.SpotId

#line default
#line hidden
#nullable disable
                , 87, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _viewModel.SpotId = __value, _viewModel.SpotId)), 88, () => _viewModel.SpotId, 89, (__builder3) => {
#nullable restore
#line 74 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                         foreach (var spot in _spots)
                        {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(90, "option");
                    __builder3.AddAttribute(91, "value", 
#nullable restore
#line 76 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                                            spot.Id

#line default
#line hidden
#nullable disable
                    );
#nullable restore
#line 76 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
__builder3.AddContent(92, spot.SpotName);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
#nullable restore
#line 77 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
                        }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(93, "\r\n                ");
                __builder2.AddMarkupContent(94, "<div class=\"text-right\"><button type=\"submit\" class=\"btn btn-primary\">Save</button></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n        ");
            __builder.AddMarkupContent(96, "<div class=\"row\"><div class=\"col-md-12\" style=\"text-align: center\"><a href=\"Memorabilia/UnsignedItems\">Back</a></div></div>\r\n        <br>");
            __builder.CloseElement();
#nullable restore
#line 92 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 94 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\Autograph\AddAutograph.razor"
       
    [Parameter]
    public int MemorabiliaId { get; set; }

    private bool _displaySpots;
    private int _itemTypeId;
    private IEnumerable<PersonViewModel> _people = Enumerable.Empty<PersonViewModel>();
    private IEnumerable<ItemTypeSpotViewModel> _spots = Enumerable.Empty<ItemTypeSpotViewModel>();
    private SaveAutographViewModel _viewModel = new SaveAutographViewModel();

    protected async Task HandleValidSubmit()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");        

        var command = new SaveAutograph.Command(_viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);

        _navigation.NavigateTo("Autographs");

        _toastService.ShowSuccess("Autograph was added successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        var query = new GetMemorabiliaItem.Query(MemorabiliaId);
        var memorabilia = await _queryRouter.Send(query).ConfigureAwait(false);

        _itemTypeId = memorabilia.ItemTypeId;

        var personQuery = new GetPeople.Query();
        _people = (await _queryRouter.Send(personQuery).ConfigureAwait(false)).People;

        _viewModel.UserId = userId.Value;
        _viewModel.MemorabiliaId = memorabilia.Id;
        _viewModel.PersonId = _people.FirstOrDefault()?.Id ?? 0;
        _viewModel.ConditionId = Domain.Constants.Condition.Pristine.Id;
        _viewModel.WritingInstrumentId = Domain.Constants.WritingInstrument.PaintPen.Id;
        _viewModel.ColorId = Domain.Constants.Color.Silver.Id;

        await GetSpots().ConfigureAwait(false);
    }

    private async Task GetSpots()
    {
        var query = new GetItemTypeSpots.Query(_itemTypeId);

        _spots = (await _queryRouter.Send(query).ConfigureAwait(false)).ItemTypeSpots;

        _displaySpots = _spots.Any();
        _viewModel.SpotId = _spots.FirstOrDefault()?.SpotId;
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
namespace __Blazor.Memorabilia.Web.Pages.Autograph.AddAutograph
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputSelect_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.AddAttribute(__seq5, "ChildContent", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.AddAttribute(__seq5, "ChildContent", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.AddAttribute(__seq5, "ChildContent", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.AddAttribute(__seq5, "ChildContent", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.AddAttribute(__seq5, "ChildContent", __arg5);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
