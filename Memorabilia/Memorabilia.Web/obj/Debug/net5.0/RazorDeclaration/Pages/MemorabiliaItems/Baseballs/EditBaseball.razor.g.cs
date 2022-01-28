// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Memorabilia.Web.Pages.MemorabiliaItems.Baseballs
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
#line 3 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Application.Features.Admin.Commissioner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Application.Features.Admin.ItemTypeBrand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Application.Features.Admin.ItemTypeSize;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Application.Features.Memorabilia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
using Memorabilia.Application.Features.Memorabilia.Baseball;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Memorabilia/Baseball/Edit/{memorabiliaId:int}")]
    public partial class EditBaseball : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "C:\Projects\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\EditBaseball.razor"
       
    [Parameter]
    public int MemorabiliaId { get; set; }  

    private _BaseballTypes _baseballType;
    private _Brands _brand;
    private IEnumerable<ItemTypeBrandViewModel> _brands = Enumerable.Empty<ItemTypeBrandViewModel>();
    private _Commissioners _commissioner;
    private IEnumerable<CommissionerViewModel> _commissioners = Enumerable.Empty<CommissionerViewModel>();
    private _Sizes _size;
    private IEnumerable<ItemTypeSizeViewModel> _sizes = Enumerable.Empty<ItemTypeSizeViewModel>();
    private SaveBaseballViewModel _viewModel = new SaveBaseballViewModel();

    protected async Task HandleValidSubmit()
    {
        var userId = await _localStorage.GetAsync<int>("UserId");

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        _viewModel.BaseballTypeId = _baseballType.BaseballTypeId;
        _viewModel.BrandId = _brand.BrandId;
        _viewModel.CommissionerId = _commissioner.CommissionerId;
        //_viewModel.MemorabiliaId = MemorabiliaId;
        _viewModel.SizeId = _size.SizeId;

        // person
        // team
        // sport

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

        await GetBrands().ConfigureAwait(false);
        await GetCommissioners().ConfigureAwait(false);
        await GetSizes().ConfigureAwait(false);

        var query = new GetBaseball.Query(MemorabiliaId);

        _viewModel = new SaveBaseballViewModel(await _queryRouter.Send(query).ConfigureAwait(false));
    }

    private async Task GetBrands()
    {
        var query = new GetItemTypeBrands.Query(Domain.Constants.ItemType.Baseball.Id);

        _brands = (await _queryRouter.Send(query).ConfigureAwait(false)).ItemTypeBrands;
    }

    private async Task GetCommissioners()
    {
        var query = new GetCommissioners.Query(Domain.Constants.Sport.Baseball.Id);

        _commissioners = (await _queryRouter.Send(query).ConfigureAwait(false)).Commissioners;
    }

    private async Task GetSizes()
    {
        var query = new GetItemTypeSizes.Query(Domain.Constants.ItemType.Baseball.Id);

        _sizes = (await _queryRouter.Send(query).ConfigureAwait(false)).ItemTypeSizes;
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
