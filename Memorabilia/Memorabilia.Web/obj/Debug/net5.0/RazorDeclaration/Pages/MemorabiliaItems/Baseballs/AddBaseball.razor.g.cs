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
#line 3 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Blazored.Typeahead;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Application.Features.Admin.Person;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Application.Features.Memorabilia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Application.Features.Memorabilia.Baseball;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Domain.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.Baseball;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.Commissioner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.GameStyleType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.ItemTypeBrand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.ItemTypeLevel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.ItemTypeSize;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.Person;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
using Memorabilia.Web.Controls.Team;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Memorabilia/Baseball/Add/{memorabiliaId:int}")]
    public partial class AddBaseball : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 160 "D:\Projects\njgrillo\Memorabilia\Memorabilia\Memorabilia.Web\Pages\MemorabiliaItems\Baseballs\AddBaseball.razor"
       
    [Parameter]
    public int MemorabiliaId { get; set; }

    private bool _continue;
    private bool _displayPeople;
    private bool _displayTeams;
    private IEnumerable<PersonViewModel> _people = Enumerable.Empty<PersonViewModel>();    
    private SaveBaseballViewModel _viewModel = new SaveBaseballViewModel();    

    protected async Task HandleValidSubmit()
    {
        var userId = await _localStorage.GetAsync<int>("UserId").ConfigureAwait(false);

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        _viewModel.MemorabiliaId = MemorabiliaId;

        var command = new SaveBaseball.Command(_viewModel);

        await _commandRouter.Send(command).ConfigureAwait(false);

        var url = _continue ? $"Memorabilia/Image/Add/{command.MemorabiliaId}" : "Memorabilia";

        _navigation.NavigateTo(url);

        _toastService.ShowSuccess("Baseball Details were added successfully!", _viewModel.PageTitle);
    }

    protected override async Task OnInitializedAsync()
    {
        var userId = await _localStorage.GetAsync<int>("UserId").ConfigureAwait(false);

        if (userId.Value == 0)
            _navigation.NavigateTo("Login");

        SetDefaults();

        await LoadPeople().ConfigureAwait(false);
    }    

    private async Task LoadPeople()
    {
        var query = new GetPeople.Query();

        _people = (await _queryRouter.Send(query).ConfigureAwait(false)).People;
    }

    private void PersonCheckboxClicked(object isChecked)
    {
        _displayPeople = (bool)isChecked;

        if (!_displayPeople)
            _viewModel.Person = null;

        StateHasChanged();
    } 

    private async Task<IEnumerable<PersonViewModel>> SearchPeople(string searchText)
    {
        return await Task.FromResult(_people.Where(person => person.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
    }

    private void SetDefaults()
    {
        _viewModel.GameStyleTypeId = GameStyleType.None.Id;
        _viewModel.BrandId = Brand.Rawlings.Id;
        _viewModel.LevelTypeId = LevelType.Professional.Id;
        _viewModel.SizeId = Size.Standard.Id;
        _viewModel.BaseballTypeId = BaseballType.Official.Id;
    }

    private void TeamsCheckboxClicked(object isChecked)
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
#pragma warning restore 1591
