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
#pragma warning restore 1591
